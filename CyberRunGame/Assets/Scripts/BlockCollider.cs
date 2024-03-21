using UnityEngine;

public class BlockingCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // If an enemy enters the collider, prevent further movement
            // You might want to add more sophisticated logic here depending on your game
            Rigidbody enemyRb = other.GetComponent<Rigidbody>();
            if (enemyRb != null)
            {
                enemyRb.velocity = Vector3.zero;
            }
        }
    }
}
