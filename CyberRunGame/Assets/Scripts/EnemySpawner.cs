using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign this in the Inspector
    public float spawnInterval = 2f; // Time between spawns
    private Camera mainCamera;
    private float timer;

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        timer = spawnInterval; // Initialize the spawn timer
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemyAtCameraEdge();
            timer = spawnInterval; // Reset the timer
        }
    }

    void SpawnEnemyAtCameraEdge()
    {
        Vector2 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0, 2) > 0 ? 1.1f : -0.1f, mainCamera.nearClipPlane));
        
        // Alternatively, for spawning at the left or right edges, use:
        // Vector2 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0, 2) > 0 ? 1.1f : -0.1f, Random.Range(0f, 1f), mainCamera.nearClipPlane));
        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
