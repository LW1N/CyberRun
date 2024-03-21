using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject shopPanel;

    public GameObject gameOverScreen;

    public PlayerHealth playerHealth;
    public Vector3 playerStartPosition;

    // Placeholder for player's gold, CHANGE PLEASE 
    public int playerGold = 0; 

    public static GameManager instance;

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

    public void ShowGameOverScreen(bool show)
    {
        gameOverScreen.SetActive(show);
        // Pause the game
        if (show) Time.timeScale = 0f; 
        // Resume the game
        else Time.timeScale = 1f; 
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
        // Hide game over screen
        ShowGameOverScreen(false);

        // Show the shop panel
        if (shopPanel != null)
        {
            shopPanel.SetActive(true);
            // Optionally, pause the game if the shop is shown or make necessary adjustments
            Time.timeScale = 0f; // Pause the game if necessary
        }
        else
        {
            Debug.LogError("Shop panel not set in GameManager.");
        }
    }

    public void ContinueGame()
    {
        // Hide game over screen and shop panel
        ShowGameOverScreen(false);
        if (shopPanel != null) shopPanel.SetActive(false);

        // Ensure the game is no longer paused
        Time.timeScale = 1f;

        // Check if the player's health component is assigned
        if (playerHealth != null)
        {
            // Directly set the player's health to maxHealth for full restoration
            playerHealth.Heal(100);
            // Respawn
            player.transform.position = playerStartPosition;
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
