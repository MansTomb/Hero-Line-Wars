using UnityEngine;

public class UnitUI : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private GameObject selectCircle;

    private void Awake()
    {
        Unselect();

        unit.Selected += Selecet;
        unit.Unselected += Unselect;
    }
    
    private void Unselect() => selectCircle.SetActive(false);
    private void Selecet() => selectCircle.SetActive(true);
}
