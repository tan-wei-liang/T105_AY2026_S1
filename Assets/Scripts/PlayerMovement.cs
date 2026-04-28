using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isMoving;

    private Rigidbody2D rb;
    private float moveInput;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        isMoving = moveInput != 0;

        animator.SetBool("isWalking", isMoving);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    public void GameOver()
    {
        moveInput = 0f;
        isMoving = false;
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        animator.SetBool("isWalking", false);
        enabled = false;
    }
}
