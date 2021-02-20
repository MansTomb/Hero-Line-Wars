using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Units List", menuName = "Data/Units List")]
public class UnitsList : ScriptableObject
{
    private readonly List<Unit> _Units = new List<Unit>();

    public List<Unit> Units => _Units;
    
    public void AddUnit(Unit unit)
    {
        if (!_Units.Contains(unit))
            _Units.Add(unit);
    }
    
    public void RemoveUnit(Unit unit)
    {
        if (_Units.Contains(unit))
            _Units.Remove(unit);
    }
}
