using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the inspector

    // This offset is for adjusting the camera's distance from the player in the Z-axis,
    // since in a 2D game, you don't want the camera to move in X and Y relative to the player,
    // but you might need it to be at a certain distance away in the Z-axis to see the scene.
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        // Here, we directly set the camera's position to the player's position plus the offset.
        // The offset ensures the camera is the correct distance away on the Z-axis.
        // Since it's a 2D game, we keep the player centered by only adjusting the camera's X and Y based on the player,
        // and we use a fixed Z value from the offset to maintain the correct viewing distance.
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
