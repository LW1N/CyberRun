using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Assign this to the player in the Inspector
    public float speed = 5f;

    void Update()
    {
        // Move towards the target each frame
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
