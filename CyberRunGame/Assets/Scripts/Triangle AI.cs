using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    public float moveSpeed = 5f; // Enemy move speed
    public float stopDistance = 10f; // Distance at which the enemy stops moving towards the player
    public GameObject fireballPrefab; // Assign a fireball prefab in the Inspector
    public float shootingInterval = 2f; // Time between shots
    private float timeSinceLastShot = 0f;

    void Update()
    {
        MoveTowardsPlayer();
        ShootAtPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Check the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // Move towards the player if further away than stopDistance
        if (distanceToPlayer > stopDistance)
        {
            // Normalize the vector to get direction and multiply by moveSpeed and deltaTime for smooth movement
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
    }

    void ShootAtPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // Shoot if within stopDistance and shootingInterval has passed
        if (distanceToPlayer <= stopDistance && timeSinceLastShot >= shootingInterval)
        {
            // Reset timeSinceLastShot
            timeSinceLastShot = 0f;
            
            // Instantiate fireball directed towards the player
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            Vector3 shootingDirection = (player.position - transform.position).normalized;
            fireball.GetComponent<Fireball>().Shoot(shootingDirection);
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }
}
