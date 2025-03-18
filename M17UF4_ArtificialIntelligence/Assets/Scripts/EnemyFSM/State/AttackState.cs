using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackState", menuName = "StatesSO/Attack")]
public class AttackState : StateSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        Debug.Log("Start Attack");
    }

    public override void OnStateExit(EnemyController ec)
    {
        Debug.Log("Exit Attack");
    }

    public override void OnStateUpdate(EnemyController ec)
    {
    }
}
