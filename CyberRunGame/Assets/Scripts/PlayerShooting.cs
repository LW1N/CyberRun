using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject beamPrefab; // Assign your beam prefab here
    public Transform firePoint; // Assign the fire point transform here
    public bool tripleShotEnabled = false; // Whether the triple shot upgrade is enabled
    public float beamSpeed = 20f; // Speed at which the beam will move

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 direction = CalculateDirection();
        if (tripleShotEnabled)
        {
            // Shoot one beam directly towards the cursor
            InstantiateBeam(firePoint.position, direction);

            // For the angled shots, calculate a slight angle to the left and right
            Vector2 leftDirection = Quaternion.Euler(0, 0, -5) * direction;
            Vector2 rightDirection = Quaternion.Euler(0, 0, 5) * direction;

            // Shoot the left and right beams with a small positional offset
            InstantiateBeam(firePoint.position + new Vector3(-0.5f, 0, 0), leftDirection);
            InstantiateBeam(firePoint.position + new Vector3(0.5f, 0, 0), rightDirection);
        }
        else
        {
            // If triple shot is not enabled, shoot a single beam towards the cursor
            InstantiateBeam(firePoint.position, direction);
        }
    }

    Vector2 CalculateDirection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)firePoint.position).normalized;
        return direction;
    }

    void InstantiateBeam(Vector2 position, Vector2 direction)
    {
        GameObject beam = Instantiate(beamPrefab, position, Quaternion.identity);
        Rigidbody2D rb = beam.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * beamSpeed;
        }
        else
        {
            Debug.LogError("Beam prefab does not have a Rigidbody2D component.");
        }
    }
}
