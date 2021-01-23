using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingPlayer : MonoBehaviour
{
    Vector2 moveDirection;
    PlayerController target;
    Gizmos gizmos;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerController>();
        Gizmos.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            moveDirection = (target.transform.position - transform.position).normalized * 5;

            Debug.DrawRay(transform.position, moveDirection, Color.green, (float)0.01);
        }
    }

}
