using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    public float moveSpeed = 5f; // Enemy move speed
    public float stopDistance = 10f; // Distance at which the enemy stops moving towards the player
    public GameObject fireballPrefab; // Assign a fireball prefab in the Inspector
    public float shootingInterval = 2f; // Time between shots
    private float timeSinceLastShot = 0f;
    private Animator myAnim;
    private Vector2 lastPosition = new Vector2(0f, 0f);
    public float interpolationSpeed = 5f;


    void Start()
    {
        myAnim = GetComponent<Animator>(); // gets Animator component
    }

    void Update()
    {
        MoveTowardsPlayer();
        ShootAtPlayer();

        // checks if distance between from last and current position has changed
        float distance = Vector2.Distance(transform.position, lastPosition);
        if (distance < 0.01f)
        {
            myAnim.SetBool("IsWalking", false);
        }   
        lastPosition = transform.position;
    }

    void MoveTowardsPlayer()
    {
        // Check the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // Move towards the player if further away than stopDistance
        if (distanceToPlayer > stopDistance)
        {
            myAnim.SetBool("IsWalking", true); // set animation to Walking state
            // Calculate the difference between player and transform positions
            float deltaX = player.position.x - transform.position.x;
            float deltaY = player.position.y - transform.position.y;

            // Smoothly interpolate the X and Y animation values
            float smoothX = Mathf.Lerp(myAnim.GetFloat("X"), deltaX, Time.deltaTime * interpolationSpeed);
            float smoothY = Mathf.Lerp(myAnim.GetFloat("Y"), deltaY, Time.deltaTime * interpolationSpeed);

            // Set the smoothed animation values
            myAnim.SetFloat("X", smoothX);
            myAnim.SetFloat("Y", smoothY);
            
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
