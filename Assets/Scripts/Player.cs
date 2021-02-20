using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UnitsList playerUnits;

    public UnitsList UnitsUnderControl => playerUnits;

    public void PlayerSpawnedUnit(Unit unit) => playerUnits.AddUnit(unit);
    public void PlayerUnitDestroyed(Unit unit) => playerUnits.RemoveUnit(unit);
}
