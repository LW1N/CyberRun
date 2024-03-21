using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private Animator myAnim;
    private int currentHealth;
    public Renderer enemyRenderer; // Reference to the enemy's renderer
    public Color damageColor = Color.grey; // Color to indicate damage
    public float colorChangeDuration = 0.2f;
    public AudioClip deathSoundClip; 
    private AudioSource audioSource;

    private Color originalColor;

    void Start()
    {
        myAnim = GetComponent<Animator>(); // gets Animator component
        currentHealth = maxHealth;

        // Get the AudioSource component from the current GameObject or add one if not present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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

            // Play death sound effect if available
            if (deathSoundClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(deathSoundClip);
            }

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
        Destroy(gameObject);
    }
}
