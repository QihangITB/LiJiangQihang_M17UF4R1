using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(fileName = "ChaseState", menuName = "StatesSO/Chase")]
public class ChaseState : StateSO
{
    public override void OnStateEnter(EnemyController ec)
    {
    }

    public override void OnStateExit(EnemyController ec)
    {
        ec.ChaseB.StopChasing();
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        ec.ChaseB.Chase(ec.Target.transform);
    }
}
