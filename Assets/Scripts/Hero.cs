public class Hero : Unit
{
    private void OnEnable()
    {
        owner = this;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        
        belongTo.AddUnit(this);
        UnitSelection.Player = this;
    }
}
