using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IdleState", menuName = "StatesSO/Idle")]
public class IdleState : StateSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        ec.PatrolB.StartPatrol();
    }

    public override void OnStateExit(EnemyController ec)
    {
        ec.PatrolB.StopPatrol();
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        ec.PatrolB.Patrol();
    }
}
