using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple script that manages the bullet spawn for the player
/// </summary>

public class Player_Bullet : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    public float nBulletSpeed = 40;

    #region Destroying Bullet Instances
    void Start()
    {
        // Remove bullet object from game after 1 seconds if not collided with enemy
        Destroy(gameObject, (float)0.5);
    }

    // Destroy bullet objects once they become off-screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    #endregion

    void Update()
    {
        this.transform.position += new Vector3(nBulletSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Assigning gameObjects with the EnemyController script the 'col' variable so only they can trigger this function
        Enemy_Controller enemy = col.GetComponent<Enemy_Controller>();
        Debug.Log(col.name);

        // Checking if enemy exists, then enemy takes damage.
        if (enemy != null)
        {
            enemy.TakeDamage(20);
        }
        Destroy(gameObject);
    }
}

