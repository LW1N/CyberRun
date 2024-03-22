using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject beamPrefab;
    public Transform firePoint;
    public float beamSpeed = 10f;
    private int moreBulletsLevel = 0;
    private int fasterBulletsLevel = 0;
    private int followingBulletsLevel = 0;
    private int strongerBulletsLevel = 0;
    private int piercingBulletsLevel = 0;
    private bool laserEnabled = false;
    public AudioClip shootingSoundClip;
    public AudioClip laserShootingSoundClip;
    public PlayerHealth playerHealth;
    private float timeSinceLastShot = 0f;
    private float fireRate = 0.5f;
    void Start()
    {
        if (firePoint == null)
        {
            Debug.LogError("Fire Point Transform has not been assigned in the PlayerShoot script.");
        }
        else if (!firePoint.gameObject.activeInHierarchy)
        {
            Debug.LogError("Fire Point GameObject is not active in the hierarchy.");
        }
    }
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        // Check if the fire button is being held, the player is alive, and the shop is not open
        if (Input.GetButton("Fire1") && playerHealth.currentHealth > 0 && !GameManager.IsShopOpen)
        {
            // Modify fire rate if laser is enabled
            float currentFireRate = laserEnabled ? 0.3f : fireRate;

            // Only shoot if enough time has elapsed based on the current fire rate
            if (timeSinceLastShot >= currentFireRate)
            {
                Shoot();
                timeSinceLastShot = 0f;
            }
        }
    }

    void Shoot()
    {
        Vector2 direction = CalculateDirection();
        int totalBullets = 1 + moreBulletsLevel;

        for (int i = 0; i < totalBullets; i++)
        {
            Vector3 positionOffset = new Vector3((i - (totalBullets - 1) / 2.0f) * 0.5f, 0, 0);
            InstantiateBeam(firePoint.position + positionOffset, direction, beamSpeed + (fasterBulletsLevel * 5));
        }
        
        AudioClip clipToPlay = laserEnabled ? laserShootingSoundClip : shootingSoundClip;

        if (clipToPlay != null)
        {
            AudioSource shootingSound = gameObject.AddComponent<AudioSource>();
            shootingSound.clip = clipToPlay;
            shootingSound.playOnAwake = false;
            shootingSound.volume = laserEnabled ? 10f : 0.1f; // Make laser sound louder
            shootingSound.Play();
            Destroy(shootingSound, clipToPlay.length);
        }
        else
        {
            Debug.LogWarning("Shooting sound clip is not assigned in the Inspector.");
        }
    }

    public void Upgrade(string upgradeType)
    {
        switch (upgradeType)
        {
            case "MoreBullets":
                moreBulletsLevel++;
                break;
            case "FasterBullets":
                fasterBulletsLevel++;
                break;
            case "FollowingBullets":
                followingBulletsLevel = followingBulletsLevel == 0 ? 1 : 0;
                break;
            case "StrongerBullets":
                strongerBulletsLevel++;
                break;
            case "PiercingBullets":
                piercingBulletsLevel++;
                break;
            case "Laser":
                laserEnabled = !laserEnabled;
                break;
            default:
                Debug.LogError("Unknown upgrade type: " + upgradeType);
                break;
        }
    }

    public int GetUpgradeLevel(string upgradeType)
    {
        switch (upgradeType)
        {
            case "MoreBullets":
                return moreBulletsLevel;
            case "FasterBullets":
                return fasterBulletsLevel;
            case "FollowingBullets":
                return followingBulletsLevel;
            case "StrongerBullets":
                return strongerBulletsLevel;
            case "PiercingBullets":
                return piercingBulletsLevel;
            case "Laser":
                return laserEnabled ? 1 : 0;
            default:
                Debug.LogError("Unknown upgrade type: " + upgradeType);
                return 0;
        }
    }

    Vector2 CalculateDirection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (mousePosition - (Vector2)firePoint.position).normalized;
    }

    void InstantiateBeam(Vector2 position, Vector2 direction, float speed)
    {
        GameObject beam = Instantiate(beamPrefab, position, Quaternion.identity);
        Rigidbody2D rb = beam.GetComponent<Rigidbody2D>();
        BeamScript beamScript = beam.GetComponent<BeamScript>();
        float lifeSpan = 1.0f;

        // Modify beam properties if laser is enabled
        if (laserEnabled)
        {
            beam.transform.localScale = new Vector3(3.0f, 1.5f, 1);
            // Change color to red
            SpriteRenderer beamSprite = beam.GetComponent<SpriteRenderer>();
            if (beamSprite != null)
            {
                beamSprite.color = Color.red;
            }
            beamScript.damageAmount = 999;
        }

        if (rb != null && beamScript != null)
        {
            rb.velocity = direction * speed;
            beamScript.damageAmount += strongerBulletsLevel * 10;
            beamScript.pierceCount = piercingBulletsLevel;
        }
        else
        {
            Debug.LogError("Beam prefab is missing required components (Rigidbody2D or BeamScript).");
        }

        Destroy(beam, lifeSpan);
    }


    GameObject FindClosestTarget(Vector2 position)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    // Method to remove all upgrades
    public void RemoveAllUpgrades()
    {
        moreBulletsLevel = 0;
        fasterBulletsLevel = 0;
        followingBulletsLevel = 0;
        strongerBulletsLevel = 0;
        piercingBulletsLevel = 0;
        laserEnabled = false;
    }
}
