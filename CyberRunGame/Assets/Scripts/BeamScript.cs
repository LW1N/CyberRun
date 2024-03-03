using UnityEngine;

public class BeamScript : MonoBehaviour
{
    // The amount of damage this beam deals
    public int damageAmount = 10; 

    void Start()
    {
        //Destroy(gameObject, 4f); // Destroy the beam after 4 seconds (doesnt work yet)
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collided with {other.gameObject.name}");
        // Check if the beam collides with an enemy
        if (other.gameObject.CompareTag("Finish")) 
        {
            // Attempt to access the EnemyHealth script on the collided object
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null) 
            {
                // Apply damage
                enemyHealth.TakeDamage(damageAmount); 
            }
            // Destroy the beam after hitting the enemy
            Destroy(gameObject); 
        }
    }
}
