using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RunState", menuName = "StatesSO/Run")]
public class RunState : StateSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        Debug.Log("Start Run");
    }

    public override void OnStateExit(EnemyController ec)
    {
        Debug.Log("Exit Run");
        ec.ChaseB.StopChasing();
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        ec.ChaseB.Run(ec.Target.transform);
    }
}
