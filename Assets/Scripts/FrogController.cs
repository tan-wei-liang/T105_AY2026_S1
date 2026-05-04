using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float holdForce = 10f;
    public float maxUpwardVelocity = 8f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Condition will be true on the frame that space
        // button was pressed and false for the following
        // frames that the button is held
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Adds specified force to rigidbody in a single frame
			// ForceMode2D.Impulse is usually used for explosions 
            // and simulating jumps
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}
}
