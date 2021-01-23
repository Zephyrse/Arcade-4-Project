using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    PlayerController target;

    private void Start()
    {
        target = GameObject.FindObjectOfType<PlayerController>();
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
