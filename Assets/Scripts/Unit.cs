using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected UnitsList ownedUnitsList;

    protected Unit _Owner;

    public event Action Selected;
    public event Action Unselected;

    private void Awake() => ownedUnitsList.AddUnit(this);
    private void OnDestroy() => ownedUnitsList.RemoveUnit(this);

    public void Select() => Selected?.Invoke();
    public void Unselect() => Unselected?.Invoke();
    public List<Unit> UnitsUnderControl() => ownedUnitsList.Units;
    public Unit Owner => _Owner;

    public void SetOwner(Unit owner) => _Owner = owner; 
    public void MoveTo(Vector3 destination) => agent.SetDestination(destination);
}
