using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float MaxHealth;
    public float Health;
    public Slider HealthBar;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        HealthBar.value = Health;
    }
}
