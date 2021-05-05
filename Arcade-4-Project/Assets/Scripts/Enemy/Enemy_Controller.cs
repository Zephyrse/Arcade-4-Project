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
public class Enemy_Controller : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public Enemy_HealthBar healthBar;
    public Transform firePoint;
    public Transform target = null;

    [SerializeField] private GameObject bullet = null;
    [SerializeField] private GameObject rev_bullet = null;

    [Header("Variables")]
    public int eHealth = 100;
    public int  eHealthThreshold = 0;
    public float fireRate;
    public float nextFire;
    public float enemyRange;
    public float nextFireTest;
    private bool isTurned;
    private int _scoreValueIncrement = 50;
    private Scene_Score _score;

    // Setting enemies max health bar value to its health as soon as the script starts
    private void Start()
    {
        var scoreText = GameObject.Find("ScoreText");
        _score = scoreText.GetComponent<Scene_Score>();

        fireRate = 2f;
        nextFire = Time.time;
        healthBar.SetMaxHealth(eHealth);
        //shootBar.SetMaxHealth((int)fireRate);
        StartCoroutine(FlipTestF());
    }

    private void Update()
    {
        if (target != null)
        {
            CheckTimeToFire();

        }

        nextFireTest += Time.deltaTime;
        //shootBar.SetHealthFloat(nextFireTest);
    }

    private void CheckTimeToFire()
    {
        if (!(nextFireTest >= fireRate) || !(Vector2.Distance(transform.position, target.position) <= enemyRange)) return;
            if (gameObject.CompareTag("Segway")) return;
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

    /* 
     * Ienumerator repeating function - checking if target exists then flipping current sprite
     * depending on the location of the existing target
    */

    private IEnumerator FlipTestF()
    {
        while (true && target != null) { 
            Vector2 toTarget = (target.position - transform.position).normalized;

            switch (Vector2.Dot(toTarget, transform.right) > 0)
            {
                case true:

                    if ((Vector2.Distance(transform.position, target.position) <= enemyRange))
                    {
                        Instantiate(bullet, firePoint.position, Quaternion.identity);
                    }

                    
                    if (isTurned == true)
                    {
                        animator.Play("Base Layer.Floating_Enim_Turn", 0, 0);

                        yield return new WaitForSeconds(0.7f);

                        if (transform.localScale.x == -0.5f)
                        {
                            transform.localScale = new Vector2(0.5f, 0.5f);
                        };

                        animator.Play("Base Layer.Floating_Enim_Idle", 0, 0);

                        isTurned = false;
                    }
                    break;

                case false:

                    if ((Vector2.Distance(transform.position, target.position) <= enemyRange))
                    {
                        Instantiate(rev_bullet, firePoint.position, Quaternion.identity);
                    }

                    if (isTurned == false)
                    {
                        animator.Play("Base Layer.Floating_Enim_Turn", 0, 0.25f);
                        yield return new WaitForSeconds(0.7f);

                        if (transform.localScale.x == 0.5f)
                        {
                            transform.localScale = new Vector2(-0.5f, 0.5f);
                        };

                        animator.Play("Base Layer.Floating_Enim_Idle", 0, 0);

                        isTurned = true;
                    }
                    break;
            }

            yield return new WaitForSeconds(1.3f);
        }
    }

    public void OnDestroy()
    {
        _score._scoreValue += _scoreValueIncrement;
    }
}
