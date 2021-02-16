using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Player player;
    [SerializeField] private float sensivity;
    [SerializeField] private float lockedSensivity;
    
    private Vector3 _MoveDirection = Vector3.zero;
    private Vector2 _Delta;
    
    private bool _Locked;


    public void OnLock(InputValue context) => _Locked = !_Locked;
    public void OnDelta(InputValue context) => _Delta = context.Get<Vector2>();
    public void OnMoveTo(InputValue context)
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if (Physics.Raycast(ray, out hit)) {
            player.MoveTo(hit.point);
        }
    }

    public void OnPosition(InputValue context)
    {
        var currentPosition = context.Get<Vector2>();
        _MoveDirection = _Locked ? GetMoveDirectionWhenLocked(currentPosition) : GetMoveDirection(currentPosition);
    }

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
    private Vector3 GetMoveDirectionWhenLocked(Vector2 currentPosition)
    {
        return new Vector3(-_Delta.x, 0, -_Delta.y);
    }


    private void MoveCamera()
    {
        var newPosition = transform.position + _MoveDirection * (Time.deltaTime * (_Locked ? lockedSensivity : sensivity));
        transform.position = newPosition;
    }

    private void Update()
    {
        MoveCamera();
    }

    private void LateUpdate()
    {
        _Delta = Vector2.zero;
    }
}
