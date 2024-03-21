using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign this in the Inspector
    public float spawnInterval = 2f; // Time between spawns
    public int maxSpawnAttempts = 10; // Maximum number of spawn attempts
    [SerializeField] private int enemyMax = 10;
    private Camera mainCamera;
    private float timer;
    private bool spawning = false;
    private int enemyCount;

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        timer = spawnInterval; // Initialize the spawn timer
    }

     void Update()
    {
        if (spawning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && enemyCount <= enemyMax)
            {
                SpawnEnemyAtCameraEdge();
                timer = spawnInterval; // Reset the timer
            }
        }
    }

    void SpawnEnemyAtCameraEdge()
    {
        for (int i = 0; i < maxSpawnAttempts; i++)
        {
            Vector2 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0, 2) > 0 ? 1.1f : -0.1f, mainCamera.nearClipPlane));
            // Check if the spawn position is within the trigger zone attached to this object
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 1f);
            
            bool isInTriggerZone = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == gameObject && collider.isTrigger)
                {
                    isInTriggerZone = true;
                    break;
                }
            }
            // If the spawn position is not in a trigger zone and not obstructed by an obstacle, spawn the enemy
            if (isInTriggerZone)
            {
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemyCount ++;
                break;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Eventually replace the tag to "Enemy" 
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log(spawning);
            spawning = true;
            enemyCount = 0;
        }
    }
}