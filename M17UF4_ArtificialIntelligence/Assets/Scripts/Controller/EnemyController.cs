using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    const float ReceiveDamage = 10;

    private HealthController _healthC;
    private ChaseBehaviour _chaseB;
    private PatrolBehaviour _patrolB;
    private StateSO _currentNode;
    public List<StateSO> Nodes;
    public GameObject Target;
    public bool OnRange = false, OnAttackRange = false;

    void Start()
    {
        InitializeComponent();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Target = collision.gameObject;
        OnRange = true;
        CheckEndingConditions();
    }

    private void OnTriggerExit(Collider collision)
    {
        OnRange = false;
        CheckEndingConditions();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnAttackRange = true;
        CheckEndingConditions();
    }

    private void OnCollisionExit(Collision collision)
    {
        OnAttackRange = false;
        CheckEndingConditions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _healthC.TakeDamage(ReceiveDamage);
        }

        _currentNode.OnStateUpdate(this);
    }

    private void InitializeComponent()
    {
        _healthC = GetComponent<HealthController>();
        _chaseB = GetComponent<ChaseBehaviour>();
        _patrolB = GetComponent<PatrolBehaviour>();
    }

    public void CheckEndingConditions()
    {
        foreach (ConditionSO condition in _currentNode.EndConditions)
            if (condition.CheckCondition(this) == condition.answer) ExitCurrentNode();
    }

    public void ExitCurrentNode()
    {
        foreach (StateSO stateSO in Nodes)
        {
            if (stateSO.StartCondition == null)
            {
                EnterNewState(stateSO);
                break;
            }
            else
            {
                if (stateSO.StartCondition.CheckCondition(this) == stateSO.StartCondition.answer)
                {
                    EnterNewState(stateSO);
                    break;
                }
            }
        }
        _currentNode.OnStateEnter(this);
    }

    private void EnterNewState(StateSO state)
    {
        _currentNode.OnStateExit(this);
        _currentNode = state;
        _currentNode.OnStateEnter(this);
    }
}
