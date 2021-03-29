using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// The main script that handles all enemies variables and functions
/// </summary>

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

    [FormerlySerializedAs("e_health")] [Header("Variables")]
    public int eHealth = 100;
    public int  eHealthThreshold = 0;
    public float fireRate;
    public float nextFire;
    public float enemyRange;
    public float nextFireTest;
    private int _scoreValueIncrement = 50;
    private Score _score;

    // Setting enemies max health bar value to its health as soon as the script starts
    private void Start()
    {
        var scoreText = GameObject.Find("ScoreText");
        _score = scoreText.GetComponent<Score>();
        
        fireRate = 2f;
        nextFire = Time.time;
        healthBar.SetMaxHealth(eHealth);
        shootBar.SetMaxHealth((int)fireRate);
        StartCoroutine(CheckDistanceAndFlip());
    }

    private void Update()
    {
        if (target != null)
        {
            CheckTimeToFire();
        }

        nextFireTest += Time.deltaTime;
        shootBar.SetHealthFloat(nextFireTest);

    }

    private void CheckTimeToFire()
    {
        if (!(nextFireTest >= fireRate) || !(Vector2.Distance(transform.position, target.position) <= enemyRange)) return;
            if (gameObject.CompareTag("Segway")) return;
                Instantiate(bullet, firePoint.position, Quaternion.identity);
                nextFireTest = 0f;
    }

    // Enemy takes damage | Updates its health and health bar value
    public void TakeDamage(int damage)
    {
        eHealth -= damage;
        healthBar.SetHealth(eHealth);

        if (eHealth <= eHealthThreshold)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator CheckDistanceAndFlip()
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

    public void OnDestroy()
    {
        _score._scoreValue += _scoreValueIncrement;
    }
    
}
