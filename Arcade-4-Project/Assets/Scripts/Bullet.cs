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

    // Check if bullet instance collided with 'obstacles', then destroy instance
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Obstacle") == true)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}

