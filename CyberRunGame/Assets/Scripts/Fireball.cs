using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    // Change the damage value here
    public int damage = 10; // Updated damage value

    public void Shoot(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }
        else
        {
            //Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Fireball collided with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
