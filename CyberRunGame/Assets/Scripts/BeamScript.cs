using UnityEngine;

public class BeamScript : MonoBehaviour
{
    public int shooterType = 0; // 0 for player shooting, 1 for enemy
    // Base damage of the beam
    public int damageAmount = 10; 
    public int pierceCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(shooterType == 0) 
        {
            // Check if the beam collides with an enemy
            if (other.gameObject.CompareTag("Enemy")) // Assuming the tag is "Enemy" for enemies
            {
                // Attempt to access the EnemyHealth script on the collided object
                EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    // Apply damage
                    enemyHealth.TakeDamage(damageAmount);
                    // Debug.Log(other.gameObject);
                    // Destroy(other.gameObject);
                }

                // Manage pierce functionality
                // pierceCount--;
                // if (pierceCount < 0)
                // {
                //     Destroy(gameObject); 
                // }
            }
        }

        else
        {
            // Check if the beam collides with player
            if (other.gameObject.CompareTag("Player")) // Assuming the tag is "Enemy" for enemies
            {
                // Attempt to access the EnemyHealth script on the collided object
                PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    // Apply damage
                    playerHealth.TakeDamage(damageAmount);
                }

                // Manage pierce functionality
                // pierceCount--;
                // if (pierceCount < 0)
                // {
                //     Destroy(gameObject); 
                // }
            }
        }
        
    }
}
