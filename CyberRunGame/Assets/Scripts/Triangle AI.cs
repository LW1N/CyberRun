using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    public Transform target; // Assign this to the player in the Inspector
    public float speed = 5f;
    public float stopDistance = 30f; // Distance at which the enemy stops moving closer

    void Update()
    {
        // Calculate the distance to the target (player)
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Check if the enemy is further away than the stopDistance
        if (distanceToTarget > stopDistance)
        {
            // Move the enemy towards the player
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        // Otherwise, the enemy is within the stopDistance and does not move closer
    }
}
