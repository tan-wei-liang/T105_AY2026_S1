using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    private float moveInputX, moveInputY;

    private Rigidbody2D rb;

    void Start()
    {
        //get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal and vertical input
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");
        //move the player
        rb.linearVelocity = new Vector2(moveInputX * movementSpeed, moveInputY * movementSpeed);
    }
}
