using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed          = 5f;
    SpriteRenderer spriteRenderer   = null;
    
    public float inputLockDuration  = 1.0f;
    float inputLockCountdown        = 0.0f;
    Vector3 initialPosition         = Vector3.zero;

    bool isInputDisabled    = false;


    void Start()
    {
        spriteRenderer  = GetComponent<SpriteRenderer>();
		initialPosition = transform.position;
	}

    void Update()
    {
        if (isInputDisabled)
        {
            return;
        }

		// Lock input while inputLockCountdown still bigger than 0.0f
		if (inputLockCountdown > 0.0f)
        {
            inputLockCountdown -= Time.deltaTime;
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX    = true;
		}

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX    = false;
		}

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
		}

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
		}
    }

    public void LockInput()
    {
        // lock input for an interval to ensure previous choice is visible
        inputLockCountdown  = inputLockDuration;
        // reset position so that it is easier to select the next choice
        transform.position      = initialPosition;
	}

    public void DisableInput(bool isDisable)
    {
		isInputDisabled = isDisable;
	}
}
