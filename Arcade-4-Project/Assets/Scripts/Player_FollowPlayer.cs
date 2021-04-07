using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FollowPlayer : MonoBehaviour
{
    public Transform playerTarget;
    public Vector3 cameraOffset;
    public Rigidbody2D playerRb;

    // Can only set the Smooth factor between a certain range
    [Range(1,30)] 
    public float smoothFactor;

    private void FixedUpdate()
    {
        if (playerRb != null)
        {
            // Call the function every fixed frame-rate frame
            SmoothFollow();
            CheckPlayerVelocity();
        }
    }

    void SmoothFollow()
    {
        // Target Position var is equal to the Players position plus the value of the Cameras Offset
        Vector3 targetPosition = playerTarget.position + cameraOffset;

        // Interpolating between the Cameras position and Target Position var then setting
        // the result as the Cameras position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }

    // This function is so that the player doesn't move out of the Camera's view
    void CheckPlayerVelocity()
    {
        if (playerRb.velocity.y < -10)
        {
            smoothFactor += 20 * Time.deltaTime;
        }
        else
        {
            smoothFactor = 10;
        }
    }
}
