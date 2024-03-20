using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float sprintSpeed = 8.0f; // Speed of the player while sprinting
    public float sprintDuration = 3.0f; // Duration of sprint in seconds

    private float sprintTimer; // Timer for sprint duration
    private bool isSprinting; // Flag to indicate if player is currently sprinting

    private float originalSpeed; // The original speed of the player

    private PlayerMovement playerMovement; // Reference to the PlayerMovement script

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Get the reference to the PlayerMovement script
        originalSpeed = playerMovement.NormalSpeed; // Get the original speed from the PlayerMovement script
        isSprinting = false;
    }

    void Update()
    {
        // Check if player can start sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSprinting)
        {
            StartSprint();
        }

        // Check if player releases sprint key while sprinting
        if (Input.GetKeyUp(KeyCode.LeftShift) && isSprinting)
        {
            StopSprint();
        }
    }

    void FixedUpdate()
    {
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
    public void StartSprint()
    {
        isSprinting = true;
        playerMovement.SetSpeed(sprintSpeed); // Set the player's speed to sprintSpeed using the SetSpeed method from PlayerMovement
        sprintTimer = sprintDuration;
    }

    // Method to stop sprinting
    public void StopSprint()
    {
        isSprinting = false;
        playerMovement.SetSpeed(originalSpeed); // Reset the player's speed to the original speed using the SetSpeed method from PlayerMovement
    }
}