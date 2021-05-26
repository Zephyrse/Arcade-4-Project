using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script handles the Player's healthbar and its functions
/// </summary>

public class Player_HealthBar : MonoBehaviour
{
    public Slider slider;
    Player_Controller target;

    private void Start()
    {
        target = GameObject.FindObjectOfType<Player_Controller>();
    }

    public void Update()
    {
        // Check if target exists
        if (target == null)
        {
            Destroy(gameObject);
        }
    }

    // Functions underneath usable in other scripts for setting health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
