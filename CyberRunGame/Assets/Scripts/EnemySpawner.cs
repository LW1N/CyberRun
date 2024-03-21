using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1; // Assign this in the Inspector
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public float zone;
    public float spawnInterval = 2f; // Time between spawns
    public LayerMask triggerLayer; // Layer mask to filter trigger zones
    private Camera mainCamera;
    private float timer;

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        timer = spawnInterval; // Initialize the spawn timer
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        bool isPlayerInTriggerZone = Physics2D.OverlapCircle(player.transform.position, 1f, triggerLayer) != null;
        Debug.Log(zone);
        Debug.Log(isPlayerInTriggerZone);
        timer -= Time.deltaTime;
        if (timer <= 0 && isPlayerInTriggerZone)
        {
            if (zone == 1)
            {
                SpawnEnemyAtZoneA();
            }
            if (zone == 2)
            {
                SpawnEnemyAtZoneB();
            }if (zone == 3)
            {
                SpawnEnemyAtZoneC();
            }
            if (zone == 4)
            {
                SpawnEnemyAtZoneD();
            }
            timer = spawnInterval; // Reset the timer
        }
    }

    void SpawnEnemyAtCameraEdge()
    {
        Vector2 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0, 2) > 0 ? 1.1f : -0.1f, mainCamera.nearClipPlane));
        
        // Alternatively, for spawning at the left or right edges, use:
        // Vector2 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0, 2) > 0 ? 1.1f : -0.1f, Random.Range(0f, 1f), mainCamera.nearClipPlane));
        
        Instantiate(enemyPrefab1, spawnPosition, Quaternion.identity);
    }

    void SpawnEnemyAtZoneA()
    {
        Vector2 spawnPosition;
        int positionNumber = Random.Range(0,2);
        switch (positionNumber){
            case 0:
            spawnPosition = new Vector2(Random.Range(-2.44f, 16f), Random.Range(14.57f, 16.2f));
            break;

            case 1:
            spawnPosition = new Vector2(Random.Range(-2.44f, 16f), Random.Range(6f, 10f));
            break;

            default:
            spawnPosition = new Vector2(Random.Range(6f, 16f), Random.Range(1.7f, 5.2f));
            break;
        }

        Instantiate(enemyPrefab1, spawnPosition, Quaternion.identity);
    }

    void SpawnEnemyAtZoneB()
    {
        Vector2 spawnPosition;
        int positionNumber = Random.Range(0,2);
        switch (positionNumber){
            case 0:
            spawnPosition = new Vector2(Random.Range(33f, 76f), Random.Range(7f, 11f));
            break;

            default:
            spawnPosition = new Vector2(Random.Range(83f, 93f), Random.Range(-29f, 22.5f));
            break;
        }

        Instantiate(enemyPrefab2, spawnPosition, Quaternion.identity);
    }

    void SpawnEnemyAtZoneC()
    {
        Vector2 spawnPosition;
        int positionNumber = Random.Range(0,3);
        switch (positionNumber){
            case 0:
            spawnPosition = new Vector2(Random.Range(32f, 82f), Random.Range(-16f, -15f));
            break;

            case 1:
            spawnPosition = new Vector2(Random.Range(64.7f, 76f), Random.Range(-32f, -17f));
            break;

            case 2:
            spawnPosition = new Vector2(Random.Range(42.16f, 49f), Random.Range(-32f, -17f));
            break;

            default:
            spawnPosition = new Vector2(Random.Range(32f, 82f), Random.Range(-37f, -33.6f));
            break;
        }

        Instantiate(enemyPrefab3, spawnPosition, Quaternion.identity);
    }

    void SpawnEnemyAtZoneD()
    {
        Vector2 spawnPosition;
        int positionNumber = Random.Range(0,2);
        switch (positionNumber){
            case 0:
            spawnPosition = new Vector2(Random.Range(-10.68f, 97.7f), Random.Range(-54.09f, -52.8f));
            break;

            case 1:
            spawnPosition = new Vector2(Random.Range(-10.68f, 97.7f), Random.Range(-49.6f, -43f));
            break;

            default:
            spawnPosition = new Vector2(Random.Range(16.75f, 30.14f), Random.Range(-39.6f, -31.74f));
            break;
        }

        Instantiate(enemyPrefab4, spawnPosition, Quaternion.identity);
    }
}
