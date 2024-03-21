using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject tutorialScreen;
    public GameObject gameOverScreen;
    public GameObject staminaBar;
    public GameObject healthBar;
    public PlayerHealth playerHealth;
    public int playerGold = 0;
    public static GameManager instance;
    public static bool IsShopOpen = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            ShowTutorialScreen(true);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        IsShopOpen = shopPanel != null && shopPanel.activeSelf;
        // Check if the B button is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            ContinueToShop();
        }
    }

    public void ShowTutorialScreen(bool show)
    {
        healthBar.SetActive(false);
        tutorialScreen.SetActive(show);
        // Pause the game
        if (show) Time.timeScale = 0f; 
        // Resume the game
        else Time.timeScale = 1f;
    }
    public void ShowGameOverScreen(bool show)
    {
        gameOverScreen.SetActive(show);
        // Pause the game when showing the game over screen
        Time.timeScale = show ? 0f : 1f;
    }

    public void RestartGame()
    {
        // Reset player's position
        playerHealth.transform.position = new Vector3(5.6f, 16.24f, 0f);

        // Reset player's health to max
        playerHealth.currentHealth = playerHealth.maxHealth;

        // Reset health bar UI
        if (playerHealth.healthSlider != null)
        {
            playerHealth.healthSlider.value = playerHealth.maxHealth;
        }

        // Reset player's money to 0 using MoneyManager
        MoneyManager.instance.money = 0;

        // Update money text
        if (MoneyManager.instance.moneyText != null)
        {
            MoneyManager.instance.moneyText.text = $"Money: ${MoneyManager.instance.money}";
        }

        shopPanel.GetComponent<ShopManager>().RemoveAllUpgrades();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }


        // Ensure to reset the game's time scale if you've paused it
        Time.timeScale = 1f;

        // Hide game over screen
        gameOverScreen.SetActive(false);
    }


    public void ContinueToShop()
    {
        bool isShopActive = shopPanel.activeSelf;
        shopPanel.SetActive(!isShopActive); // Toggle the active state of the shop panel

        // Pause the game if the shop panel is now active, otherwise unpause
        Time.timeScale = isShopActive ? 1f : 0f;
    }

    public void ContinueGame()
    {
        // Hide game over screen and shop panel
        ShowGameOverScreen(false);
        if (shopPanel != null) shopPanel.SetActive(false);
        
        tutorialScreen.SetActive(false);
    
        staminaBar.SetActive(true);
        healthBar.SetActive(true);

        // Ensure the game is no longer paused
        Time.timeScale = 1f;

        // Check if the player's health component is assigned
        if (playerHealth != null)
        {
            // Directly set the player's health to maxHealth for full restoration
            playerHealth.Heal(100);
        }
        else
        {
            Debug.LogError("PlayerHealth component not set in GameManager.");
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }


    // Method to update player's gold (you might manage this elsewhere, e.g., in a PlayerInventory script)
    public void UpdatePlayerGold(int amount)
    {
        playerGold += amount;
    }
}
