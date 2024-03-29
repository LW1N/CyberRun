using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    private Animator myAnim;
    private Vector2 lastPosition = new Vector3(0f, 0f, 0f);
    public GameObject projectilePrefab; // Assign a fireball prefab in the Inspector
    public float projectileSpeed = 10f;
    public float moveSpeed = 5f; // Enemy move speed
    public float stopDistance = 10f; // Distance at which the enemy stops moving towards the player
    public float shootingInterval = 2f; // Time between shots
    private float timeSinceLastShot = 0f;
    
    private EnemyHealth enemyHealth;
    public float interpolationSpeed = 5f;
    [SerializeField] private float marginOfError = 0.01f;
    private Collider[] colliders;
    private Rigidbody2D rb;
    


    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        myAnim = GetComponent<Animator>(); // gets Animator component
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int currentHealth = enemyHealth.GetCurrentHealth();
        if (currentHealth <= 0)
        {
            gameObject.tag = "Enemy Dead";
            rb.simulated = false; // Set simulated to false so it doesn't respond to physics
            return;
        }
        
        MoveTowardsPlayer();
        ShootAtPlayer();

        // checks if distance between from last and current position has changed
        float distance = Vector2.Distance(transform.position, lastPosition);
        if (distance < marginOfError)
        {
            myAnim.SetBool("IsWalking", false);
        }
        else
        {
            myAnim.SetBool("IsWalking", true); // set animation to Walking state
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            
            // Set the smoothed animation values
            myAnim.SetFloat("X", directionToPlayer.x);
            myAnim.SetFloat("Y", directionToPlayer.y);
        }

        lastPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            
            // Instantiate projectile directed towards the player
            InstantiateBeam(((Vector2)player.position - (Vector2)transform.position).normalized, projectileSpeed);
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }
    void InstantiateBeam(Vector2 direction, float speed)
    {
        Vector3 firePoint = new Vector3(transform.position.x, transform.position.y + 1f, 0f);
        GameObject beam = Instantiate(projectilePrefab, firePoint, Quaternion.identity);
        Rigidbody2D rb = beam.GetComponent<Rigidbody2D>();
        BeamScript beamScript = beam.GetComponent<BeamScript>();
        float lifeSpan = 1.0f;

        if (rb != null && beamScript != null)
        {
            rb.velocity = direction * speed;
        }
        else
        {
            Debug.LogError("Beam prefab is missing required components (Rigidbody2D or BeamScript).");
        }

        // Clean gameobject after certain time
        Destroy(beam, lifeSpan);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Projectile"))
        {
            // Destroy the bullet when it collides with an enemy
            Destroy(other.gameObject);
        }
    }
}
