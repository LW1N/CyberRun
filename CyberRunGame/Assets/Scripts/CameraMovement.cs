using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 1.5f, -10); // Adjust the y offset to position the camera at the torso level

    // Define the boundaries
    public float minX = -1.75f;
    public float maxX = 99f;
    public float minY = -68f;
    public float maxY = 21f;

    void LateUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = player.position + offset;

        // Clamp camera's position within the boundaries
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Update the camera's position
        transform.position = clampedPosition;
    }
}

