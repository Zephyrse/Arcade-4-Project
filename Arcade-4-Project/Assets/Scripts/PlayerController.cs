using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    private bool isGrounded;
    public float    moveSpeed = 3f;
    public float    jumpForce;
    public float checkRadius;
    public Vector3  movement;
    public Transform groundCheck;
    public LayerMask checkGroundLayer;

    [SerializeField] private int extraJumps;
    [SerializeField] private int extraJumpsValue = 2;

    void Start()
    {
        extraJumps = extraJumpsValue;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, checkGroundLayer);
        // Movement equals the Horizontal movement of the player (Check input manager for button inputs)
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        // Adding the results of movement, deltatime and moveSpeed to the Players Position values
        // This code is independant of framerates due to Time.deltaTime
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        Jump();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            // Adding force on the Y axis if the jump button is pressed
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            extraJumps--;
        }
    }
}
