using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 20f;
    public Rigidbody2D rb;

    void Start()
    {

        // Bullet travels to the right of where it spawns consistant to the calculation below
        rb.velocity = transform.right * moveSpeed;

        // Remove bullet object from game after 1 seconds if not collided with enemy
        Destroy(gameObject, 1);

        
    }
}

