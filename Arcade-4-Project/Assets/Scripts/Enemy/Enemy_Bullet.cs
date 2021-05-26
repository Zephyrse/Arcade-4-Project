using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    public float nBulletSpeed;
    public Vector2 velocity;
    Player_Controller target;
    Enemy_Controller enemy;
    
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<Player_Controller>();
        enemy = GameObject.FindObjectOfType<Enemy_Controller>();
        moveDirection = (target.transform.position - transform.position).normalized;
        Debug.Log(moveDirection);

        rb.velocity = new Vector2(velocity.x, velocity.y);

        Debug.Log(enemy.transform.localScale.x);


        //Debug.DrawRay(transform.position, moveDirection, Color.green, 1);
        Destroy(gameObject, (float)2.5);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Assigning gameObjects with the PlayerController script the 'col' variable so only they can trigger this function
        Player_Controller player = col.GetComponent<Player_Controller>();
        Debug.Log(col.name);

        // Checking if enemy exists, then enemy takes damage.
        if (player != null)
        {
            player.TakeDamage(20);
        }
        Destroy(gameObject);
    }

    // Destroy bullet objects once they become off-screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
