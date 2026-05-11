using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed	= 5.0f;
	public bool isUsingAxes	= false;

	private SpriteRenderer sr	= null;

	[SerializeField]
	float inputLockDuration		= 1.0f;
	float inputLockCountdown	= 0.0f;

	PlayerChoice pc	= null;

	void Start()
	{
		sr	= GetComponent<SpriteRenderer>();
		pc	= GetComponent<PlayerChoice>();
	}

	void Update()
	{
		if (inputLockCountdown > 0.0f)
		{
			inputLockCountdown	-= Time.deltaTime;
			return;
		}

		if (isUsingAxes)
		{
			ProcessAxes_Movement();
		}
		else
		{
			ProcessKeys_WASD();
		}
	}

	void ProcessAxes_Movement()
	{
		Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		transform.Translate(movementInput * moveSpeed * Time.deltaTime);

		if (movementInput.x != 0.0f)
		{
			sr.flipX = movementInput.x > 0.0f ? false : true;
			pc.HideChoice();
		}
	}

	void ProcessKeys_WASD()
	{
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
			sr.flipX = true;
			pc.HideChoice();
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
			sr.flipX = false;
			pc.HideChoice();
		}

		// TODO: Add movement for W
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
			pc.HideChoice();
		}

		// TODO: Add movement for S
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
			pc.HideChoice();
		}
	}

	public void LockInput()
	{
		inputLockCountdown = inputLockDuration;
	}
}