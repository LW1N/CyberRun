using UnityEngine;

public class EnemyAI : MonoBehaviour
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
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            InstantiateBeam(((Vector2)player.position - (Vector2)transform.position).normalized, 20f);
            // Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            // Vector3 shootingDirection = (player.position - transform.position).normalized;
            // Vector3 shootingDirection = (player.position);
            // fireball.GetComponent<Fireball>().Shoot(shootingDirection);
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }
    void InstantiateBeam(Vector2 direction, float speed)
    {
        GameObject beam = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
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
        Debug.LogError("Shoot at " + direction);
        Debug.LogError("Velocity is " + rb.velocity);


        // Clean gameobject after certain time
        // Destroy(beam, lifeSpan);
    }
}
