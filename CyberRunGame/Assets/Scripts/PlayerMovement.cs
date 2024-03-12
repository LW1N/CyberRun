using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the player

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get Animator component
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get input from horizontal axis (A/D, Left/Right Arrow)
        float moveVertical = Input.GetAxis("Vertical"); // Get input from vertical axis (W/S, Up/Down Arrow)

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (movement.x !=0 || movement.y !=0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); // Move the player
    }
}
