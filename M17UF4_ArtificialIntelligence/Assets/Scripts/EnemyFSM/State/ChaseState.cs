using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState", menuName = "StatesSO/Chase")]
public class ChaseState : StateSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        Debug.Log("Start Chase");
    }

    public override void OnStateExit(EnemyController ec)
    {
        Debug.Log("Exit Chase");
        ec.ChaseB.StopChasing();
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        ec.ChaseB.Chase(ec.Target.transform);
    }
}
