using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementBehaviour : MonoBehaviour
{
    const float Double = 2f;

    public float Speed;
    public List<Transform> Waypoints;
    public float MinDistanceToWaypoint;
    public float WaitTime;

    private NavMeshAgent _agent;
    private bool _isPatrolling = false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void StartAgent()
    {
        _isPatrolling = false;
    }

    public void StopAgent()
    {
        _agent.ResetPath();
    }

    public void Patrol()
    {
        if (HasArrivedToWaypoint() && !_isPatrolling)
        {
            Transform destination = GetRandomWaypoint();
            StartCoroutine(WaitAndSetDestination(destination.position));
        }
    }

    private bool HasArrivedToWaypoint()
    {
        return _agent.remainingDistance < MinDistanceToWaypoint;
    }

    private IEnumerator WaitAndSetDestination(Vector3 destination)
    {
        _isPatrolling = true;

        yield return new WaitForSeconds(WaitTime);

        _agent.SetDestination(destination);

        _isPatrolling = false;
    }

    private Transform GetRandomWaypoint()
    {
        return Waypoints[Random.Range(0, Waypoints.Count)];
    }

    public void Run(Transform target)
    {
        Vector3 direction = (transform.position - target.position).normalized;
        direction.y = 0;

        _agent.Move(direction * Speed * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * Speed * Double);
    }

    public void Chase(Transform target)
    {
        _agent.SetDestination(target.position);
    }
}
