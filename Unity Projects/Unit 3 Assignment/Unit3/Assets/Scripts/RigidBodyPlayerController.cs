using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyPlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;

    private Rigidbody rb; 
    private Animator animator;

    void Start()
    {
        //looks for the rigidbody on the player
        rb = GetComponent<Rigidbody>();
        //looks for animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("idle", true);
        

        //Allows for player to move horizontally and vertically using the rigidbody
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);

        //checks if jump button has been pressed
        if(Input.GetButtonDown("Jump"))
        {
            //if pressed, lets player move on the y axis
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        }
    }
}
