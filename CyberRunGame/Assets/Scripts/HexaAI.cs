using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; 
    public float speed = 5f;

    void Update()
    {
        // Move towards the target each frame
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
