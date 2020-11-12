using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    [Header("Bullet Settings")]
    public float bulletSpeed = 40.0f;

    void Update()
    {
        // If button pressed, execute Shoot() function
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Spawns an instance of the Bullet Prefab and grabs a reference to its Rigidbody for later use
        Rigidbody2D bulletRb = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Rigidbody2D>();
        bulletRb.AddRelativeForce(new Vector2(bulletSpeed, 0.0f), ForceMode2D.Impulse);
    }
}
