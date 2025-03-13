using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider healthBar;

    public float TakeDamage(float health, float damage)
    {
        health -= damage;
        healthBar.value = health;
        return health;
    }
}
