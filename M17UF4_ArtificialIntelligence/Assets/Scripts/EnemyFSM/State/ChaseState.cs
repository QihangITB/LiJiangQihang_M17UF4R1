using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState", menuName = "StatesSO/Chase")]
public class ChaseState : StateSO
{
    public override void OnStateEnter(EnemyController ec)
    {
    }

    public override void OnStateExit(EnemyController ec)
    {
        ec.ChaseBehaviour.StopChasing();
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        ec.ChaseBehaviour.Chase(ec.Target.transform);
    }
}
