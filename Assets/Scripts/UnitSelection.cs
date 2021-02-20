using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private RectTransform selectionBox;
    [SerializeField] private Camera playerCamera;

    private Player _Player;
    private Vector2 _StartPos = Vector2.zero;
    private bool _SelectHolded;
    
    private List<Unit> _SelectedUnits = new List<Unit>();

    public List<Unit> Units => _SelectedUnits;

    private void Awake() => _Player = GetComponent<Player>();

    private void OnEnable()
    {
        inputReader.OnSelection += OnSelection;
    }

    private void Update()
    {
        if (_SelectHolded)
            UpdateSeletction(InputReader.GetMousePosition());
    }

    private void OnSelection(bool state)
    {
        if (state)
        {
            selectionBox.gameObject.SetActive(false);
            _SelectedUnits.ForEach(x => x.Unselect());
            _SelectedUnits = new List<Unit>();
            if (TrySelectUnit(InputReader.GetMousePosition()))
                return;
            _StartPos = InputReader.GetMousePosition();
            return;
        }

        if (_SelectHolded)
            StopSelection();
        
        _SelectHolded = false;
    }

    private bool TrySelectUnit(Vector2 mousePos)
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(mousePos);
        
        if (Physics.Raycast(ray, out hit)) {
            var unit = hit.collider.GetComponent<Unit>();

            if (unit != null && _Player.UnitsUnderControl.Units.Contains(unit))
            {
                unit.Select();
                _SelectedUnits.Add(unit);
                return true;
            }
        }
        _SelectHolded = true;
        return false;
    }
    
    private void UpdateSeletction(Vector2 currentMousePos)
    {
        if (!selectionBox.gameObject.activeInHierarchy)
            selectionBox.gameObject.SetActive(true);

        float width = currentMousePos.x - _StartPos.x;
        float height = currentMousePos.y - _StartPos.y;
        
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = _StartPos + new Vector2(width / 2, height / 2);
    }

    private void StopSelection()
    {
        _SelectHolded = false;
        selectionBox.gameObject.SetActive(false);

        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

        if (_Player == null)
            return;

        foreach (var unit in _Player.UnitsUnderControl.Units)
        {
            Vector3 screenPos = playerCamera.WorldToScreenPoint(unit.transform.position);
            
            if (screenPos.x >= min.x && screenPos.x <= max.x && screenPos.y >= min.y && screenPos.y <= max.y)
            {
                unit.Select();
                _SelectedUnits.Add(unit);
            }
        }
    }
}
