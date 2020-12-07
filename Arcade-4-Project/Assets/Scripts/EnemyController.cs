using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour
{
    [Header("References")]
    public HealthBar healthBar;
    public Transform firePoint;
    public GameObject player;
    [SerializeField]
    private GameObject bullet;

    [Header("Variables")]
    public int e_health = 100;
    public int  e_health_threshold = 0;
    public float fireRate;
    public float nextFire;

    // Setting enemies max healthbar value to its health as soon as the script starts
    void Start()
    {
        fireRate = 2f;
        nextFire = Time.time;
        healthBar.SetMaxHealth(e_health);
    }

    void Update()
    {
        if (player != null)
        {
            CheckTimeToFire();
        }
    }

    void CheckTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    // Enemy takes damage | Updates its health and healthbar value
    public void TakeDamage(int damage)
    {
        e_health -= damage;
        healthBar.SetHealth(e_health);

        if (e_health <= e_health_threshold)
        {
            EnemyDeath();
        }
    }

    // On death, destroys the object this script is attached to
    void EnemyDeath()
    {
        Destroy(gameObject);
    }






}
