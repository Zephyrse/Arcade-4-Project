using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_TestScript : MonoBehaviour
{
    public Transform playerTarget;
    public Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = playerTarget.position + cameraOffset;
        transform.position = targetPosition;
    }
}
