using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform playerPosition;
    public GameObject beamPrefab;
    public float shootingInterval = 2f;
    private float shootTimer;
    public float beamSpeed = 20f; 
    public Transform firePoint; 

    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootingInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }
    void Shoot()
    {
        int totalBullets = 1;

        for (int i = 0; i < totalBullets; i++)
        {
            Vector3 positionOffset = new Vector3((i - (totalBullets - 1) / 2.0f) * 0.5f, 0, 0);
            InstantiateBeam(firePoint.position + positionOffset, (Vector2)playerPosition.position, beamSpeed);
        }
    }
    // DOES NOT WORK YET :[

    void InstantiateBeam(Vector2 position, Vector2 direction, float speed)
    {
        GameObject beam = Instantiate(beamPrefab, position, Quaternion.identity);
        Rigidbody2D rb = beam.GetComponent<Rigidbody2D>();
        BeamScript beamScript = beam.GetComponent<BeamScript>();
        float lifeSpan = 1.0f;

        if (rb != null && beamScript != null)
        {
            rb.velocity = direction * speed;

            // beamScript.damageAmount += strongerBulletsLevel * 10;
            // beamScript.pierceCount = piercingBulletsLevel;
        }
        else
        {
            Debug.LogError("Beam prefab is missing required components (Rigidbody2D or BeamScript).");
        }

        // Clean gameobject after certain time
        Destroy(beam, lifeSpan);
    }
}
