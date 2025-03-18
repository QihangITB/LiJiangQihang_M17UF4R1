using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IdleState", menuName = "StatesSO/Idle")]
public class IdleState : StateSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        Debug.Log("Start Idle");
    }

    public override void OnStateExit(EnemyController ec)
    {
        Debug.Log("Exit Idle");
    }

    public override void OnStateUpdate(EnemyController ec)
    {
    }
}
