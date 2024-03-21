using UnityEngine;

public class BeamScript : MonoBehaviour
{
    public int shooterType = 0; // 0 for player shooting, 1 for enemy
    public int damageAmount = 10; 
    public int pierceCount = 0;
    private GameObject target;
    private float speed;
    private bool isFollowing = false;

    // Call this method to make the beam follow a target
    public void SetToFollow(GameObject newTarget, float newSpeed)
    {
        target = newTarget;
        speed = newSpeed;
        isFollowing = true;
    }

    void Update()
    {
        if (isFollowing && target != null)
        {
            // Calculate the direction from the beam to the target
            Vector2 direction = (target.transform.position - transform.position).normalized;
            // Apply the calculated direction and speed to the beam's Rigidbody2D
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (shooterType == 0) 
        {
            if (other.gameObject.CompareTag("Enemy")) 
            {
                EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageAmount);
                }

                if (isFollowing && other.gameObject == target)
                {
                    // Target hit, stop following
                    isFollowing = false;
                }

                if (pierceCount <= 0)
                {
                    Destroy(gameObject); // No pierce left, destroy the beam
                }
                else
                {
                    pierceCount--; // Reduce pierce count
                }
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player")) 
            {
                PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                }

                if (isFollowing && other.gameObject == target)
                {
                    // Target hit, stop following
                    isFollowing = false;
                }

                if (pierceCount <= 0)
                {
                    Destroy(gameObject); // No pierce left, destroy the beam
                }
                else
                {
                    pierceCount--; // Reduce pierce count
                }
            }
        }
    }
}
