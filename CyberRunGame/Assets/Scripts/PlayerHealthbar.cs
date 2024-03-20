using UnityEngine;
using UnityEngine.UI; // Include this for UI updates

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider == null) {
            Debug.Log("No healthSlider object");
        }

        else{
            healthSlider.maxValue = maxHealth;
            // Update the UI at the start
            UpdateHealthUI(); 
            Debug.Log("Player Health system initialized."); 
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Ensure health doesn't go below 0 or above max
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        Debug.Log($"Player took {damage} damage. Current Health: {currentHealth}/{maxHealth}");
        UpdateHealthUI(); 

        if (currentHealth <= 0)
        {
            Debug.Log("Player Died");
            GameManager.instance.ShowGameOverScreen(true);
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Player healed {amount}. Current Health: {currentHealth}/{maxHealth}");
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            Debug.Log($"Updating UI with Current Health: {currentHealth}"); 
            healthSlider.value = currentHealth;
        }
        else
        {
            Debug.Log("Health Text component not assigned!"); 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Eventually replace the tag to "Enemy" 
        if (collision.gameObject.CompareTag("Finish")) 
        {
            TakeDamage(50);
            Debug.Log("Collision with Enemy detected."); 
        }
    }
}
