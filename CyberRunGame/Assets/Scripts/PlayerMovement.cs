using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the player

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get input from horizontal axis (A/D, Left/Right Arrow)
        float moveVertical = Input.GetAxis("Vertical"); // Get input from vertical axis (W/S, Up/Down Arrow)

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); // Move the player
    }
}
