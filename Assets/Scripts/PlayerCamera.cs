using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Camera playerCamera;

    [SerializeField] private float sensivity;
    [SerializeField] private float lockedSensivity;

    private UnitSelection _UnitSelection;
    
    private Vector3 _MoveDirection = Vector3.zero;
    private Vector2 _Delta;
    
    private bool _Locked;

    private void Awake()
    {
        _UnitSelection = GetComponent<UnitSelection>();
    }

    private void OnEnable()
    {
        inputReader.OnLock += OnLock;
        inputReader.OnMouseDelta += OnDelta;
        inputReader.OnMousePosition += OnPosition;
        inputReader.OnMoveOrAttack += OnMoveTo;
    }

    private void Update()
    {
        MoveCamera();
    }
    
    private void MoveCamera()
    {
        var parentTransform = transform;
        var newPosition = parentTransform.position + _MoveDirection * (Time.deltaTime * (_Locked ? lockedSensivity : sensivity));
        parentTransform.position = newPosition;
    }
    
    public void OnLock(bool value) => _Locked = value;
    public void OnDelta(Vector2 value) => _Delta = value;

    public void OnPosition(Vector2 value) => _MoveDirection = _Locked ? GetMoveDirectionWhenLocked(value) : GetMoveDirection(value);
    public void OnMoveTo()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(InputReader.GetMousePosition());
        
        if (Physics.Raycast(ray, out hit)) {
            _UnitSelection.Units.ForEach(x => x.MoveTo(hit.point));
        }
    }

    private Vector3 GetMoveDirectionWhenLocked(Vector2 currentPosition) => new Vector3(-_Delta.x, 0, -_Delta.y);

    private Vector3 GetMoveDirection(Vector2 currentPosition)
    {
        var width = Screen.width;
        var height = Screen.height;
        var direction = Vector3.zero;
        
        if (currentPosition.x > width)
            direction += Vector3.right;
        else if (currentPosition.x <= 0)
            direction += Vector3.left;
        if (currentPosition.y > height)
            direction += Vector3.forward;
        else if (currentPosition.y <= 0)
            direction += Vector3.back;
        
        return direction;
    }
}
