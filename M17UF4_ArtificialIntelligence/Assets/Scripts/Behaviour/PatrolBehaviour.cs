using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : MonoBehaviour
{
    public List<Transform> Waypoints;
    public float MinDistanceToWaypoint = 0.5f;
    private NavMeshAgent _agent;
    private bool isPatrolling = false; 

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void StopPatrol()
    {
        _agent.ResetPath();
    }

    public void Patrol()
    {
        if (HasArrivedToWaypoint() && !isPatrolling)
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
        isPatrolling = true;

        yield return new WaitForSeconds(1f);

        _agent.SetDestination(GetRandomWaypoint().position);

        isPatrolling = false;
    }

    private Transform GetRandomWaypoint()
    {
        return Waypoints[Random.Range(0, Waypoints.Count)];
    }
}
