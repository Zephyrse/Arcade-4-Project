using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TrackingPlayer : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private int target_ray_length;

    Vector2 moveDirection;
    Player_Controller target;
    Gizmos gizmos;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player_Controller>();
        Gizmos.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            moveDirection = (target.transform.position - transform.position).normalized * target_ray_length;

            Debug.DrawRay(transform.position, moveDirection, Color.green, (float)0.01);
        }
    }

}
