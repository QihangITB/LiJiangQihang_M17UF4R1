using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DeadCondition", menuName = "ConditionSO/Death")]
public class DeathConditionSO : ConditionSO
{
    public override bool CheckCondition(EnemyController ec)
    {
        float health = ec.gameObject.GetComponent<HealthController>().Health;
        return health <= 0;
    }
}
