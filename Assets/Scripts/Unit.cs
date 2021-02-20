using System;
using GameEvents;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : NetworkBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected UnitSO unitData;

    private UnitsList _BelongsTo;
    private UnitsList _Enemies;

    protected bool _Selected;

    public Unit owner;
    
    public event Action Selected;
    public event Action Unselected;

    public virtual void Init(UnitsList belongsTo, UnitsList enemies)
    {
        _BelongsTo = belongsTo;
        _Enemies = enemies;

        health = unitData.health;
        agent.speed = unitData.moveSpeed;
    }
    
    public void Select()
    {
        _Selected = true;
        Selected?.Invoke();
    }

    public void Unselect()
    {
        _Selected = false;
        Unselected?.Invoke();
    }
    
    [Command]
    public void MoveTo(Vector3 destination) => agent.SetDestination(destination);
}
