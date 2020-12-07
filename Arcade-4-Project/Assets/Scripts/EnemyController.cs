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
    public float enemyRange;

    // Setting enemies max healthbar value to its health as soon as the script starts
    void Start()
    {
        fireRate = 2f;
        nextFire = Time.time;
        healthBar.SetMaxHealth(e_health);
        //StartCoroutine(CheckDistance());
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
        if (Time.time > nextFire && Vector2.Distance(transform.position, player.transform.position) <= enemyRange)
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
            Destroy(gameObject);
        }
    }

    //// Debug Function, checking the position between enemy and player
    //public IEnumerator CheckDistance()
    //{
    //    while (true)
    //    {
    //        Debug.Log(Vector2.Distance(transform.position, player.transform.position));
    //        yield return new WaitForSeconds(1.0f);
    //    }
    //}





}
