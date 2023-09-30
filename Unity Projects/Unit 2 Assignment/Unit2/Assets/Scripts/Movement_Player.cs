using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animate;
    private SpriteRenderer sprite;
    private BoxCollider2D boxC;

    public LayerMask jumpGround;

    public int height = 0; 
    public int speed = 0;
    private float moveVelocity;

    private enum MovementState { idle, run, jump, fall }

    // Start is called before the first frame update
    private void Start()
    {
        //calls rigid body
        rb = GetComponent<Rigidbody2D>();
        //calls animator
        animate = GetComponent<Animator>();
        //calls sprite renderer
        sprite = GetComponent<SpriteRenderer>();
        //calls for Box Collider
        boxC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Non-Stick player
        moveVelocity = 0.0f;

        //assigns jumping to the space key
        if (Input.GetKey(KeyCode.W) && Grounded())
        {
            rb.velocity = new Vector3(0, height, 0);
        }

        //assigns right movement to D
        if(Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }

        //assigns left movement to A
        if(Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }

        //Moves the character left and right
        rb.velocity = new Vector3(moveVelocity, rb.velocity.y);

        UpdateAnimation();
    }

    //changes running animation between true and false
    private void UpdateAnimation()
    {
        MovementState state;

        //checks if we are idle or running and flips sprite
        if(moveVelocity > 0.0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }   
        else if(moveVelocity < 0.0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        //checks the y velocity to see if we are jumping or falling
        if(rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if(rb.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }

        animate.SetInteger("State", (int)state);
    }

    private bool Grounded()
    {
        //creates box over box collider to sense for a ground layer
        return Physics2D.BoxCast(boxC.bounds.center, boxC.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
