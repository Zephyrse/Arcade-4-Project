using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

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
        // Spawns an instance of the Bullet Prefab
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
