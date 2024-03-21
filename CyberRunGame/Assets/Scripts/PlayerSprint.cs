using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float sprintSpeed = 8.0f; // Speed of the player while sprinting
    public float sprintDuration = 3.0f; // Duration of sprint in seconds
    public float depletionRate = 0.5f; // Rate the stamina depletes while sprinting
    public float regenerationRate = 0.2f; // Rate the stamina regenerates when not sprinting

    private float sprintTimer; // Timer for sprint duration
    private bool isSprinting; // Flag to indicate if player is currently sprinting

    private float originalSpeed; // The original speed of the player

    private PlayerMovement playerMovement;
    private StaminaBar staminaBar; 

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        originalSpeed = playerMovement.NormalSpeed; 
        isSprinting = false;

        staminaBar = FindObjectOfType<StaminaBar>();
    }

    void Update()
    {
        // Check if player can start sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSprinting && staminaBar.CurrentStamina > 0)
        {
            StartSprint();
        }

        // Check if player releases sprint key while sprinting or if stamian is currently depleted
        if ((Input.GetKeyUp(KeyCode.LeftShift) && isSprinting) || ((staminaBar.CurrentStamina <= 0) && isSprinting))
        {
            StopSprint();
        }
    }

    void FixedUpdate()
    {
        // Update sprint timer if player is sprinting
        if (isSprinting)
        {
            staminaBar.DecreaseStamina(depletionRate * Time.fixedDeltaTime);
            sprintTimer -= Time.fixedDeltaTime;
            if (sprintTimer <= 0)
            {
                StopSprint();
            }
        }
        if (!isSprinting)
        {
            staminaBar.IncreaseStamina(regenerationRate * Time.fixedDeltaTime);
        }
    }

    // Method to start sprinting
    public void StartSprint()
    {
        isSprinting = true;
        playerMovement.SetSpeed(sprintSpeed); 
        sprintTimer = sprintDuration;
    }

    // Method to stop sprinting
    public void StopSprint()
    {
        isSprinting = false;
        playerMovement.SetSpeed(originalSpeed);
    }
}