using System.Collections; 
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private Animator myAnim;
    private int currentHealth;
    public Renderer enemyRenderer; // Reference to the player's renderer
    public Color damageColor = Color.grey; // Color to indicate damage
    public float colorChangeDuration = 0.2f;

    private Color originalColor;

    void Start()
    {
        myAnim = GetComponent<Animator>(); // gets Animator component
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
            StartCoroutine(DeadAnimation()); // Start the DeadAnimation coroutine
            MoneyManager.instance.AddMoney(10);
            EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        }
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    IEnumerator ChangeColorTemporary(Color color)
    {
        enemyRenderer.material.color = color;
        yield return new WaitForSeconds(colorChangeDuration);
        enemyRenderer.material.color = Color.white;
    }
    IEnumerator DeadAnimation()
    {
        myAnim.SetBool("IsDead", true);
        damageColor = Color.white;
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
