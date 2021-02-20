using UnityEngine;

public class Mob : Unit
{
    [SerializeField] private PlayerDetector detector;
    
    [SerializeField] private float attackRadius;
    
    private Transform _FinalDestination;

    public void Init(UnitsList belongsTo, UnitsList enemies, Transform destination)
    {
        base.Init(belongsTo, enemies);

        agent.stoppingDistance = attackRadius - 1f;
        owner = this;
        
        _FinalDestination = destination;
        MoveTo(_FinalDestination.position);
    }

    private void Attack()
    {
        agent.SetDestination(detector.Target.transform.position);
    }

    private void Update()
    {
        if (_Selected) return;
        
        if (detector.Target != null)
            Attack();
        else
            MoveTo(_FinalDestination.position);
    }
}
