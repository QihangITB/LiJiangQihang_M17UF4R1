using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : MonoBehaviour
{
    public List<Transform> Waypoints;
    public float MinDistanceToWaypoint = 1f;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Patrol()
    {
        if (HasArrivedToWaypoint())
        {
            _agent.SetDestination(GetRandomWaypoint().position);
        }
    }

    private bool HasArrivedToWaypoint()
    {
        return _agent.remainingDistance < MinDistanceToWaypoint;
    }

    private Transform GetRandomWaypoint()
    {
        return Waypoints[Random.Range(0, Waypoints.Count)];
    }


}
