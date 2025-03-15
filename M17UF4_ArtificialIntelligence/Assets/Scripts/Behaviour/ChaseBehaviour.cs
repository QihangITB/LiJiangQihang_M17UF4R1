using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    public float Speed;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Escapa del jugador
    public void Run(Transform target)
    {
        Vector3 direction = (transform.position - target.position).normalized;
        direction.y = 0;
        _rb.velocity = direction * Speed;
    }

    // Persigue al jugador
    public void Chase(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        _rb.velocity = direction * Speed;
    }

    public void StopChasing()
    {
        _rb.velocity = Vector3.zero;
    }
}