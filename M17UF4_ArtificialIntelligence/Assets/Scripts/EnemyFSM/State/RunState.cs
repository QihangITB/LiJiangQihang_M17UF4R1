using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RunState", menuName = "StatesSO/Run")]
public class RunState : StateSO
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
        ec.ChaseBehaviour.Run(ec.Target.transform);
    }
}
