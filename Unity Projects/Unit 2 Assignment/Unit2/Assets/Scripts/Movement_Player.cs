using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animate;
    private SpriteRenderer sprite;
    public int height = 0; 
    public int speed = 0;
    private float moveVelocity;

    // Start is called before the first frame update
    private void Start()
    {
        //calls rigid body
        rb = GetComponent<Rigidbody2D>();
        //calls animator
        animate = GetComponent<Animator>();
        //calls sprite renderer
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Non-Stick player
        moveVelocity = 0.0f;

        //assigns jumping to the space key
        if (Input.GetKey(KeyCode.W))
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
            if(moveVelocity > 0.0f)
        {
            animate.SetBool("Running", true);
            sprite.flipX = false;
        }   
        else if(moveVelocity < 0.0f)
        {
            animate.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
        {
            animate.SetBool("Running", false);
        }
    }
}
