using UnityEngine;

public class Mob : Unit
{
    [SerializeField] private Transform finalDestination;
    
    [SerializeField] private PlayerDetector detector;
    
    [SerializeField] private float attackRadius;

    protected void Awake()
    {
        belongTo.AddUnit(this);
        
        MoveTo(finalDestination.position);
        agent.stoppingDistance = attackRadius - 1f;
        
        owner = this;
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
            MoveTo(finalDestination.position);
    }
}
