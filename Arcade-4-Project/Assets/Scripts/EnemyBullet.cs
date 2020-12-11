using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    public float nBulletSpeed;
    PlayerController target;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerController>();
        moveDirection = (target.transform.position - transform.position).normalized * nBulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Debug.DrawRay(transform.position, moveDirection, Color.green, 1);
        Destroy(gameObject, (float)0.5);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        // Assigning gameObjects with the EnemyController script the 'col' variable so only they can trigger this function
        PlayerController player = col.GetComponent<PlayerController>();
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
