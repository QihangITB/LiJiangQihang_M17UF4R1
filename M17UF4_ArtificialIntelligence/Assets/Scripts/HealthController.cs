using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider healthBar;
    private float health;

    void Start()
    {
        health = transform.GetComponent<EnemyController>().Health;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 10;
            healthBar.value = health;
        }
    }
}
