using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform
    public float smoothSpeed = 10f; // Smoothing factor for camera movement

    private bool isInitialized = false;

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not set for TopDownCameraFollow script.");
            return;
        }

        // Initialize camera rotation once
        if (!isInitialized)
        {
            transform.LookAt(target);
            isInitialized = true;
        }

        // Get the player's position
        Vector3 targetPosition = target.position;

        // Set the camera's position to follow the player on the x and z axes, keeping the same y position
        Vector3 desiredPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
