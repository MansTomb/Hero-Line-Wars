using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform finalDestination;
    [SerializeField] private PlayerDetector detector;
    [SerializeField] private float attackRadius;

    private void Awake()
    {
        MoveToDestination();
        agent.stoppingDistance = attackRadius - 1f;
    }

    private void MoveToDestination() => agent.SetDestination(finalDestination.position);

    private void Attack()
    {
        agent.SetDestination(detector.Target.transform.position);
    }

    private void Update()
    {
        if (detector.Target != null)
            Attack();
        else
            MoveToDestination();
    }
}
