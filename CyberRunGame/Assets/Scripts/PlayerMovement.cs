using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 5.0f; // Normal speed of the player
    public float sprintSpeed = 8.0f; // Speed of the player while sprinting
    public float sprintDuration = 3.0f; // Duration of sprint in seconds

    private float currentSpeed; // Current speed of the player
    private float sprintTimer; // Timer for sprint duration
    private bool isSprinting; // Flag to indicate if player is currently sprinting

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get Animator component

        // Set initial speed to normal speed
        currentSpeed = normalSpeed;
        isSprinting = false;
    }

    void Update()
    {
        // Check if player can start sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSprinting)
        {
            StartSprint();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get input from horizontal axis (A/D, Left/Right Arrow)
        float moveVertical = Input.GetAxis("Vertical"); // Get input from vertical axis (W/S, Up/Down Arrow)

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Determine speed based on sprinting status
        currentSpeed = isSprinting ? sprintSpeed : normalSpeed;

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

        // Update sprint timer if player is sprinting
        if (isSprinting)
        {
            sprintTimer -= Time.fixedDeltaTime;
            if (sprintTimer <= 0)
            {
                StopSprint();
            }
        }
    }

    // Method to start sprinting
    void StartSprint()
    {
        isSprinting = true;
        currentSpeed = sprintSpeed;
        sprintTimer = sprintDuration;
    }

    // Method to stop sprinting
    void StopSprint()
    {
        isSprinting = false;
        currentSpeed = normalSpeed;
    }
}