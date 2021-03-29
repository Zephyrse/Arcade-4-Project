using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// The main script that handles all of the players variables and functions.
/// Notable functions/methods: Damage and Healing calculations, flipping player sprite, movement calculations.
/// </summary>

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;

    [Header("References")]
    public Animator animator;
    public PlayerHealthBar healthBar;
    public TextMeshProUGUI Text;
    public GameObject cameraRef;
    public GameObject destination;
    public GameObject bossBox1;
    public GameObject bossBoxTest;
    public GameObject Boss;

    [Header("Variables")]
    public float moveSpeed = 3f;
    public float jumpForce;
    public float checkRadius;
    public Vector3 movement;
    public float horizontalMoving;
    public Transform groundCheck;
    public LayerMask checkGroundLayer;
    public LayerMask checkGameOverMask;
    public bool facingRight;
    [FormerlySerializedAs("p_health")] public int pHealth = 100;
    [FormerlySerializedAs("p_health_max")] public int pHealthMAX = 100;
    [FormerlySerializedAs("p_health_threshold")] public int pHealthThreshold = 0;


    [SerializeField] private int extraJumps;
    [SerializeField] private int extraJumpsValue;
    private Vector3 _playerScale;
    private bool _isGrounded;
    private bool _isGameOver;

    private bool _isBossBattle1 = false;
    private bool _isBossBattle2 = false;

    private void Start()
    {
        facingRight = true;
        extraJumps = extraJumpsValue;
        healthBar.SetMaxHealth(pHealth);
        Text.enabled = false;

    }

    private void FixedUpdate()
    {
        // Checks for player
        var position = groundCheck.position;
        _isGrounded = Physics2D.OverlapCircle(position, checkRadius, checkGroundLayer);
        _isGameOver = Physics2D.OverlapCircle(position, checkRadius, checkGameOverMask);

        // Movement equals the Horizontal movement of the player (Check input manager for button inputs)
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        horizontalMoving = Input.GetAxisRaw("Horizontal") * moveSpeed;

        // Adding the results of movement, deltatime and moveSpeed to the Players Position values
        // This code is independent of framerate due to Time.deltaTime
        transform.position += movement * (Time.deltaTime * moveSpeed);
        Flip(movement);

        if (_isBossBattle1)
        {
            bossBox1.SetActive(true);
            //bossBoxTest.SetActive(true);
            cameraRef.GetComponent<FollowPlayer>().enabled = false;
            cameraRef.transform.position = Vector3.SmoothDamp(cameraRef.transform.position, destination.transform.position, ref velocity, 3f);
        }

    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMoving));



        if (_isGrounded == true)
        {
            animator.SetBool("isJumping", false);
            extraJumps = extraJumpsValue;
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        if (_isGameOver == true)
        {
            Destroy(gameObject);
            Text.enabled = true;
        }

        Jump();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            animator.SetBool("isJumping", true);
            // Adding force on the Y axis if the jump button is pressed
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //extraJumps--;
        }
    }

    public void TakeDamage(int damage)
    {
        pHealth -= damage;
        healthBar.SetHealth(pHealth);

        if (pHealth <= pHealthThreshold)
        {
            Destroy(gameObject);
        }
    }

    public void HealDamage(int damage)
    {
        pHealth += damage;
        healthBar.SetHealth(pHealth);

        if (pHealth > pHealthMAX)
        {
            pHealth = pHealthMAX;
        }
    }

    private void Flip(Vector3 movement)
    {
        if ((!(movement.x > 0f) || facingRight) && (!(movement.x < 0) || !facingRight)) return;
            facingRight = !facingRight;

            Vector3 playerScale = transform.localScale;
            playerScale = transform.localScale;

            playerScale.x *= -1;
            transform.localScale = playerScale;
    }

    public void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Boss_Battle_1"))
        {
            _isBossBattle1 = true;
            Boss.SetActive(true);
        }
    }





}
