using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public PlayerHealthBar healthBar;

    [Header("Variables")]
    public float    moveSpeed = 3f;
    public float    jumpForce;
    public float    checkRadius;
    public Vector3  movement;
    public float horizontalMoving;
    public Transform groundCheck;
    public LayerMask checkGroundLayer;
    public LayerMask checkGameOverMask;
    public bool facingRight;
    public int p_health = 100;
    public int p_health_max = 100;
    public int p_health_threshold = 0;

    [SerializeField] private int extraJumps;
    [SerializeField] private int extraJumpsValue = 2;
    private Vector3 _playerScale;
    private bool _isGrounded;
    private bool _isGameOver;

    void Start()
    {
        facingRight = true;
        extraJumps = extraJumpsValue;
        healthBar.SetMaxHealth(p_health);
    }

    void FixedUpdate()
    {
        // Checks for player
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, checkGroundLayer);
        _isGameOver = Physics2D.OverlapCircle(groundCheck.position, checkRadius, checkGameOverMask);
        // Movement equals the Horizontal movement of the player (Check input manager for button inputs)
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        horizontalMoving = Input.GetAxisRaw("Horizontal") * moveSpeed;
        // Adding the results of movement, deltatime and moveSpeed to the Players Position values
        // This code is independant of framerates due to Time.deltaTime
        transform.position += movement * Time.deltaTime * moveSpeed;
        Flip(movement);
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMoving));

        if (_isGrounded == true)
        {
            animator.SetBool("isJumping", false);
            extraJumps = extraJumpsValue;
        }

        if (_isGameOver == true)
        {
            Destroy(gameObject);
        }

        Jump();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            animator.SetBool("isJumping", true);
            // Adding force on the Y axis if the jump button is pressed
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            extraJumps--;
        }
    }

    public void TakeDamage(int damage)
    {
        p_health -= damage;
        healthBar.SetHealth(p_health);

        if (p_health <= p_health_threshold)
        {
            Destroy(gameObject);
        }
    }

    public void HealDamage(int damage)
    {
        p_health += damage;
        healthBar.SetHealth(p_health);

        if (p_health > p_health_max)
        {
            p_health = p_health_max;
        }
    }

    private void Flip(Vector3 movement)
    {
        if(movement.x > 0f && !facingRight || movement.x < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 playerScale = transform.localScale;
            playerScale = transform.localScale;

            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }

}
