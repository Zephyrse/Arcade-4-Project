using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public EnemyController enemy;
    public GameObject destructableObject;

    private void Update()
    {
        if (enemy == null)
        {
            Destroy(destructableObject);
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

    public void SetHealthFloat(float health)
    {
        slider.value = health;
    }
}
