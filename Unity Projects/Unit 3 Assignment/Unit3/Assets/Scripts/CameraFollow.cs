using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    //The target to follow (player)
    public float smoothSpeed = 5.0f;  //how smooth the camera is
    public Vector3 offset = new Vector3(0, 3, -5);  //how close or far the camera is from payer
    void LateUpdate()
    {
        if (target == null)
            return;

        //calculates camera position
        Vector3 desiredPosition = target.position + offset;

        //uses Lerp to smoothly move the camera towards the desired position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        //sets the camera's position to the smoothed position.
        transform.position = smoothedPosition;

        //makes the camera look at the player
        transform.LookAt(target);
    }
}

