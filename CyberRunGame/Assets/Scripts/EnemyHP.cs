using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // Initialize the enemy's health.
        currentHealth = maxHealth; 
    }
    public void TakeDamage(int damage)
    {
        // Reduce the current health by the damage amount.
        currentHealth -= damage; 
        
        // Current health for debugging.
        Debug.Log($"Enemy Health: {currentHealth}/{maxHealth}");

        // Check if the enemy's health has dropped to zero or below.
        if (currentHealth <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
