using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour
{
    [Header("References")]
    public EnemyHealthBar healthBar;
    public EnemyHealthBar shootBar;
    public Transform firePoint;
    public Transform target = null;


    [SerializeField]
    private GameObject bullet = null;

    [Header("Variables")]
    public int e_health = 100;
    public int  e_health_threshold = 0;
    public float fireRate;
    public float nextFire;
    public float enemyRange;
    public float nextFireTest;

    // Setting enemies max healthbar value to its health as soon as the script starts
    void Start()
    {
        fireRate = 2f;
        nextFire = Time.time;
        healthBar.SetMaxHealth(e_health);
        shootBar.SetMaxHealth((int)fireRate);
        StartCoroutine(CheckDistanceAndFlip());
    }

    void Update()
    {
        if (target != null)
        {
            CheckTimeToFire();
        }

        nextFireTest += Time.deltaTime;
        shootBar.SetHealthFloat(nextFireTest);

    }

    void CheckTimeToFire()
    {
        if (nextFireTest >= fireRate && Vector2.Distance(transform.position, target.position) <= enemyRange)
        {
            if (gameObject.tag != "Segway") {
                Instantiate(bullet, firePoint.position, Quaternion.identity);
                nextFireTest = 0f;
            }
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

    public IEnumerator CheckDistanceAndFlip()
    {
        while (true && target != null)
        {
            //Debug.Log(Vector2.Distance(transform.position, player.transform.position));
            //yield return new WaitForSeconds(1.0f);

            Vector2 toTarget = (target.position - transform.position).normalized;

            if (Vector2.Dot(toTarget, transform.right) < 0)
            {
                if (transform.localScale.x == -0.1f)
                {
                    transform.localScale = new Vector2(0.1f, 0.1f);
                };

            }
            else
            {
                if (transform.localScale.x == 0.1f)
                {
                    transform.localScale = new Vector2(-0.1f, 0.1f);
                };
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

}
