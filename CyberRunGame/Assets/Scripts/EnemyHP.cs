using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy Health: {currentHealth}/{maxHealth}");
        // Drops money upon death 
        if (currentHealth <= 0)
        {
            MoneyManager.instance.AddMoney(10);
            Destroy(gameObject);
        }
    }
}
