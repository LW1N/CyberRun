using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float currentSpeed; // Current speed of the player

    private Rigidbody2D rb;
    private Animator animator;
    private PlayerSprint playerSprint;

    public float NormalSpeed { get; private set; } = 5.0f; // Normal speed of the player
    private int framesToSkip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get Animator component

        // Set initial speed to normal speed
        SetSpeed(NormalSpeed);

        // Get reference to the PlayerSprint script
        playerSprint = GetComponent<PlayerSprint>(); // Changed reference to PlayerSprint script
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            // Find mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; 

            // Find the direction vector from the player to the mouse
            Vector3 directionToMouse = mousePosition - transform.position;
            directionToMouse.Normalize(); // Normalize the direction vector if you need unit length

            animator.SetFloat("X", directionToMouse.x);
            animator.SetFloat("Y", directionToMouse.y);
            framesToSkip = 2;

        }
    }

    void FixedUpdate()
    {
        // Check if we need to skip this FixedUpdate
        if (framesToSkip > 0)
        {
            // Reset the flag
            framesToSkip --;
            return; // Skip the execution of this FixedUpdate
        }

        float moveHorizontal = Input.GetAxis("Horizontal"); // Get input from horizontal axis (A/D, Left/Right Arrow)
        float moveVertical = Input.GetAxis("Vertical"); // Get input from vertical axis (W/S, Up/Down Arrow)

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Set animator parameters
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        // Move the player
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }

    // Method to set the speed of the player
    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Method to start sprinting
    public void StartSprint()
    {
        playerSprint.StartSprint();
    }

    // Method to stop sprinting
    public void StopSprint()
    {
        playerSprint.StopSprint();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Projectile"))
        {
            // Destroy the bullet when it collides with an enemy
            Destroy(other.gameObject);
        }
    }
}