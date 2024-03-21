using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 1.5f, -10); // Adjust the y offset to position the camera at the torso level

    void LateUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = player.position + offset;

        // Update the camera's position
        transform.position = desiredPosition;
    }
}