using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (target == null)
        {
            Destroy(gameObject);
        }
    }

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
