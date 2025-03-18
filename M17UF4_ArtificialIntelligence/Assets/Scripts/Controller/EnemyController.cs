using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    const string PlayerTag = "Player";
    const float ReceiveDamage = 10;

    private HealthController _healthC;
    private ChaseBehaviour _chaseB;
    private PatrolBehaviour _patrolB;
    private StateSO _currentNode;
    public List<StateSO> Nodes;
    public GameObject Target;
    public bool OnRange = false, OnAttackRange = false;

    public HealthController HealthC { get => _healthC; set => _healthC = value; }
    public ChaseBehaviour ChaseB { get => _chaseB; set => _chaseB = value; }
    public PatrolBehaviour PatrolB { get => _patrolB; set => _patrolB = value; }


    void Start()
    {
        InitializeComponent();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(PlayerTag))
        {
            Target = collision.gameObject;
            OnRange = true;
            CheckEndingConditions();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(PlayerTag))
        {
            OnRange = false;
            CheckEndingConditions();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(PlayerTag))
        {
            OnAttackRange = true;
            CheckEndingConditions();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(PlayerTag))
        {
            OnAttackRange = false;
            CheckEndingConditions();
        }
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

        _currentNode = Nodes[Nodes.Count - 1];
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
