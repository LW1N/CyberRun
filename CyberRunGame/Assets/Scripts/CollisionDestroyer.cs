using System.Collections; 
using UnityEngine;

public class CollisionDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Projectile")) 
        {
            Destroy(collision.gameObject); 
        }
        
        if (collision.gameObject.CompareTag("Player Projectile")) 
        {
            Destroy(collision.gameObject); 
        }
    }
}
