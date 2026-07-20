using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    //update isn't a good place to do anything related to physics. frame rate constantly changes, which makes physics unreliable
    //still use update for registering our input
    void Update()
    {
       //Input
       movement.x =  Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
    }
    //recommended to use fixedupdate, as it's executed on a fixed timer, and not dependent on the frame rate like Update is. By default it's called 50 times /second
    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
