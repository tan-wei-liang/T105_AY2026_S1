using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float jumpForce			= 5f;
    public float holdForce			= 10f;
    public float maxUpwardVelocity	= 8f;

	public float dashForce			= 5.0f;
	SpriteRenderer spriteRenderer	= null;

    private Rigidbody2D rb;

    private void Start()
    {
        rb				= GetComponent<Rigidbody2D>();
		spriteRenderer	= GetComponent<SpriteRenderer>();
	}

    private void Update()
    {
		ProcessDirectionKeys();
		ProcessShiftKey();
		ProcessSpaceKey();
	}

	// Handles logic related to keys bound to Horizontal axis in
	// Edit > Project Settings > Input Manager > Axes
	// Sets sprite's flipX to true if left is pressed
	// Sets sprite's flipX to false if right is pressed
	void ProcessDirectionKeys()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		if (horizontalInput == 0.0f)
		{
			return;
		}

		spriteRenderer.flipX = (horizontalInput < 0.0f) ? true : false;
	}

	// Handles logic related to Shift key
	// Rigidbody2D will dash in the direction the sprite is facing
	void ProcessShiftKey()
	{
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			Vector3 dirDashForce = transform.right * dashForce * (spriteRenderer.flipX ? -1.0f : 1.0f);
			rb.AddForce(dirDashForce, ForceMode2D.Impulse);
		}
	}

	// Encapsulation of previous body of Update()
	// Handles logic related to Space key
	void ProcessSpaceKey()
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

		// Condition will be true on the frame that space
		// button was pressed and true for the following
		// frames that the button is held IF rigidbody is
		// still moving upwards
		if (Input.GetKey(KeyCode.Space) && rb.linearVelocity.y > 0.0f)
		{
			// Compares current linearVelocity of rigidbody with
			// class variable, maxUpwardVelocity
			if (rb.linearVelocity.y < maxUpwardVelocity)
			{
				// Continue apply force so that player jumps higher while
				// Space button is held down
				rb.AddForce(Vector2.up * holdForce, ForceMode2D.Force);
			}
		}

		// Condition will be true on the frame that space
		// button was released
		if (Input.GetKeyUp(KeyCode.Space))
		{
			// Half frog's upwards speed by half when space button is released
			// Frog will start falling faster
			if (rb.linearVelocity.y > 0)
			{
				rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
			}
		}
	}
}
