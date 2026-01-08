using UnityEngine;
public class AlienMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // How fast the alien moves
    private Rigidbody2D rb;
    private float horizontalInput;
    void Start()
    {
        // Get the Rigidbody2D component on the alien
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Get input from arrow keys or A/D
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        // Move the alien horizontally
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }
}
