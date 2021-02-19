using UnityEngine;

public class UnitUI : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private GameObject selectCircle;

    private void Awake()
    {
        unit.Selected += () => selectCircle.SetActive(true);
        unit.Unselected += () => selectCircle.SetActive(false);
    }
}
