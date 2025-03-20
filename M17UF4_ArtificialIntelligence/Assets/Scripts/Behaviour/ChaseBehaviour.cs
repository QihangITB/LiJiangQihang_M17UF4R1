using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : MonoBehaviour
{
    public float Speed;
    private Rigidbody _rb;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
    }

    // Escapa del jugador
    public void Run(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        _rb.velocity = direction * Speed;
    }

    // Persigue al jugador
    public void Chase(Transform target)
    {
        _agent.SetDestination(target.position);
    }

    public void StopChasing()
    {
        _rb.velocity = Vector3.zero;
    }
}