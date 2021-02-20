using GameEvents;
using UnityEngine;

public class Hero : Unit
{
    [SerializeField] private UnitEvent onSpawn;
    
    private void OnEnable()
    {
        owner = this;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        
        onSpawn.Raise(this);
    }
}
