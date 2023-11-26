using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        // Get input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player
        MovePlayer(movement);
    }

    private void MovePlayer(Vector3 movement)
    {
        // Move the player based on input
        Vector3 moveDirection = transform.TransformDirection(movement);
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
