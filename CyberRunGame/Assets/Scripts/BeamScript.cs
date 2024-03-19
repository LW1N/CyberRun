using UnityEngine;

public class BeamScript : MonoBehaviour
{
    // Base damage of the beam
    public int damageAmount = 10; 
    public int pierceCount = 0; 

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the beam collides with an enemy
        if (other.gameObject.CompareTag("Finish")) // Assuming the tag is "Enemy" for enemies
        {
            // Attempt to access the EnemyHealth script on the collided object
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Apply damage
                enemyHealth.TakeDamage(damageAmount);
            }

            // Manage pierce functionality
            pierceCount--;
            if (pierceCount < 0)
            {
                Destroy(gameObject); 
            }
        }
    }
}
