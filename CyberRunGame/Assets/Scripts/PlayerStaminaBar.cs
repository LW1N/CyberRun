using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider; // Reference to the stamina bar slider
    public float maxStamina = 100f; // Maximum stamina value
    private float currentStamina; // Current stamina value

    // Property to get the current stamina value
    public float CurrentStamina
    {
        get { return currentStamina; }
    }

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaBar(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Method to update the stamina bar
    void UpdateStaminaBar()
    {
        slider.value = currentStamina / maxStamina; // Update the fill amount of the stamina bar slider
    }

    // Method to decrease stamina
    public void DecreaseStamina(float amount)
    {
        currentStamina -= amount; // Decrease stamina by the specified amount
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina); 
        UpdateStaminaBar(); // Update the stamina bar
    }

    // Method to increase stamina
    public void IncreaseStamina(float amount)
    {
        currentStamina += amount; // Increase stamina by the specified amount
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        UpdateStaminaBar(); // Update the stamina bar
    }
}