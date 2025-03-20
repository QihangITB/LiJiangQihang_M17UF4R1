using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : MonoBehaviour
{
    public List<Transform> Waypoints;
    public float MinDistanceToWaypoint = 0.5f;
    public float WaitTime = 1f;
    private NavMeshAgent _agent;
    private bool _isPatrolling = false; 

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void StartPatrol()
    {
        _isPatrolling = false;
    }

    public void StopPatrol()
    {
        _agent.ResetPath();
    }

    public void Patrol()
    {
        if (HasArrivedToWaypoint() && !_isPatrolling)
        {
            StartCoroutine(WaitAndSetDestination());
        }
    }

    private bool HasArrivedToWaypoint()
    {
        return _agent.remainingDistance < MinDistanceToWaypoint;
    }

    private IEnumerator WaitAndSetDestination()
    {
        _isPatrolling = true;

        yield return new WaitForSeconds(WaitTime);

        _agent.SetDestination(GetRandomWaypoint().position);

        _isPatrolling = false;
    }

    private Transform GetRandomWaypoint()
    {
        return Waypoints[Random.Range(0, Waypoints.Count)];
    }
}
