using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple script that allows for the player to "pickup" objects such as health packs.
/// </summary>

public class Scene_PickupableObjects : MonoBehaviour
{
    [Header("References")]
    Scene_PickupableObjects healthPickup;
    Player_Controller player;

    [Header("Values")]
    public int heal_value = 20;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player_Controller>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        healthPickup = GetComponent<Scene_PickupableObjects>();
        Debug.Log(col.name);

        if (player != null)
        {
            if (healthPickup.CompareTag("Health_Pickup"))
            {
                player.HealDamage(heal_value);
            }
        }
        Destroy(gameObject);
    }






}
