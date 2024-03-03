using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint; // The point from which the beam will be fired
    public GameObject beamPrefab; // Drag your beam prefab here in the inspector
    public float beamSpeed = 20f; // Adjust as necessary

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Default mouse left click or Ctrl
        {
            ShootBeam();
        }
    }

    void ShootBeam()
    {
        if (beamPrefab == null)
        {
            Debug.LogError("Beam prefab is not assigned!");
            return; // Stop the method here
        }
        // Calculate direction from firePoint to mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)firePoint.position).normalized;

        // Instantiate the beam
        GameObject beam = Instantiate(beamPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = beam.GetComponent<Rigidbody2D>();

        // Set the beam's velocity
        rb.velocity = direction * beamSpeed;
    }
}
