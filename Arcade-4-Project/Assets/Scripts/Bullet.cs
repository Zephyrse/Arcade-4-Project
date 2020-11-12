using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;

    #region Destroying Bullet Instances
    void Start()
    {
        // Bullet travels to the right of where it spawns consistant to the calculation below
        //rb.velocity = transform.right * moveSpeed;

        // Remove bullet object from game after 1 seconds if not collided with enemy
        Destroy(gameObject, (float)0.5);
    }

    // Destroy bullet objects once they become off-screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    #endregion

    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyController enemy = col.GetComponent<EnemyController>();
        Debug.Log(col.name);

        if (enemy != null)
        {
            enemy.TakeDamage(20);
        }
        Destroy(gameObject);
    }
}

