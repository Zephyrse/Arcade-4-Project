using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Assigning gameObjects with the PlayerController script the 'col' variable so only they can trigger this function
        Player_Controller player = col.GetComponent<Player_Controller>();
        Debug.Log(col.name);

        // Checking if enemy exists, then enemy takes damage.
        if (player != null)
        {
            player.TakeDamage(20);
        }
    }

}
