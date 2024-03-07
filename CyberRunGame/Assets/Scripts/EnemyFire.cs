using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform player;
    public GameObject beamPrefab;
    public float shootingInterval = 2f;
    private float shootTimer;

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootingInterval)
        {
            ShootBeam();
            shootTimer = 0f;
        }
    }
    // DOES NOT WORK YET :[
    void ShootBeam()
    {

        GameObject beam = Instantiate(beamPrefab, transform.position, Quaternion.identity);
        beam.transform.LookAt(player.position);

    }
}
