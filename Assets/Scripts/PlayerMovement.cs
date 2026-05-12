using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed          = 5f;
    SpriteRenderer spriteRenderer   = null;
    
    public float choiceDisplayDuration  = 1.0f;
    float choiceDisplayCountdown        = 0.0f;
    PlayerChoice playerChoice           = null;
    Vector3 initialPosition             = Vector3.zero;


    void Start()
    {
        spriteRenderer  = GetComponent<SpriteRenderer>();
        playerChoice    = GetComponent<PlayerChoice>();
		initialPosition = transform.position;
	}

    void Update()
    {
		// Lock input while choiceDisplayCountdown still bigger than 0.0f
		if (choiceDisplayCountdown > 0.0f)
        {
            choiceDisplayCountdown -= Time.deltaTime;
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX    = true;
			playerChoice.HideChoice();
		}

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX    = false;
			playerChoice.HideChoice();
		}

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
			playerChoice.HideChoice();
		}

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
			playerChoice.HideChoice();
		}
    }

    public void LockInput()
    {
        // lock input for an interval to ensure previous choice is visible
        choiceDisplayCountdown  = choiceDisplayDuration;
        // reset position so that it is easier to select the next choice
        transform.position      = initialPosition;
	}
}
