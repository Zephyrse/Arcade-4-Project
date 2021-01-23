using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObjects : MonoBehaviour
{
    [Header("References")]
    PickupableObjects healthPickup;
    PlayerController player;

    [Header("Values")]
    public int heal_value = 20;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        healthPickup = GetComponent<PickupableObjects>();
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
