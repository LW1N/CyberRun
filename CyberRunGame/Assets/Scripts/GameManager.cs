using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject shopPanel;

    public GameObject gameOverScreen;

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

    public void ShowGameOverScreen(bool show)
    {
        gameOverScreen.SetActive(show);
        // Pause the game when showing the game over screen
        Time.timeScale = show ? 0f : 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Ensure to reset the game's time scale if you've paused it
        Time.timeScale = 1f;
        // Reset other game states as needed
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

        // Ensure the game is no longer paused
        Time.timeScale = 1f;
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
