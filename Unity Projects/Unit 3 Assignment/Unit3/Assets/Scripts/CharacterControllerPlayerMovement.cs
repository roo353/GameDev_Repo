using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;

public class CharacterControllerPlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpHeight;

    public CharacterController controller;
    private Vector3 direction;

    void Start()
    {
        //gets built in character controller from unity
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Allows for player to move horizontally and vertically using the Character Controller
        direction = new Vector3(Input.GetAxis("Horizonal") * speed, 0f, Input.GetAxis("Vertical") * speed);

        //checks if jump button has been pressed
        if(Input.GetButtonDown("Jump"))
        {
            //if pressed, lets player move on the y axis
            direction.y = jumpHeight;
        }

        controller.Move(direction * Time.deltaTime);
    }
}
