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
        
    }
}
