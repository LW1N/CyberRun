using System.Collections; 
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Renderer enemyRenderer; // Reference to the player's renderer
    public Color damageColor = Color.grey; // Color to indicate damage
    public float colorChangeDuration = 0.2f;

    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy Health: {currentHealth}/{maxHealth}");
        if (enemyRenderer != null)
        {
            // Change color temporarily to indicate damage
            StartCoroutine(ChangeColorTemporary(damageColor));
        }

        // Drops money upon death 
        if (currentHealth <= 0)
        {
            MoneyManager.instance.AddMoney(10);
            Destroy(this.gameObject);
        }
    }
    IEnumerator ChangeColorTemporary(Color color)
    {
        enemyRenderer.material.color = color;
        yield return new WaitForSeconds(colorChangeDuration);
        enemyRenderer.material.color = Color.white;
    }
}
