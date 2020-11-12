using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    // Variables
    [Header("Variables")]
    public float    moveSpeed = 3f;
    public Vector3  movement;

    void Update()
    {
        Jump();
        // Movement equals the Horizontal movement of the player (Check input manager for button inputs)
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        // Adding the results of movement, deltatime and moveSpeed to the Players Position values
        // This code is independant of framerates due to Time.deltaTime
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

}
