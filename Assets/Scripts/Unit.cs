using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : NetworkBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected NavMeshAgent agent;
    
    [SerializeField] protected UnitsList belongTo;

    public Unit owner;

    protected bool _Selected;

    public event Action Selected;
    public event Action Unselected;

    private void OnDestroy() => belongTo.RemoveUnit(this);

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


    public List<Unit> Units() => belongTo.Units;

    [Command]
    public void MoveTo(Vector3 destination) => agent.SetDestination(destination);
}
