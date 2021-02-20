using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input")]
public class InputReader : ScriptableObject
{
    public DefautActionMap ActionMap;

    private bool _CameraLocked;
    private bool _ChooseHolded;
    
    public event Action OnMoveOrAttack;
    public event Action<Vector2> OnMousePosition;
    public event Action<Vector2> OnMouseDelta;
    
    public event Action<bool> OnSelection;
    public event Action<bool> OnLock;
    
    public void OnEnable()
    {
        if (ActionMap == null)
        {
            ActionMap = new DefautActionMap();
            ActionMap.Enable();
        }

        _ChooseHolded = false;
        _CameraLocked = false;
        
        ActionMap.Gameplay.Choose.performed += Choose;
        ActionMap.Gameplay.LockCamera.performed += Lock;
        ActionMap.Gameplay.MoveOrAttack.performed += MoveOrAttack;
        ActionMap.Gameplay.MousePosition.performed += MousePosition;
        ActionMap.Gameplay.MouseDelta.performed += MouseDelta;
    }

    public static Vector3 GetMousePosition() => Mouse.current.position.ReadValue();

    private void MouseDelta(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnMouseDelta?.Invoke(context.ReadValue<Vector2>());
    }

    private void MousePosition(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnMousePosition?.Invoke(context.ReadValue<Vector2>());
    }

    private void MoveOrAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnMoveOrAttack?.Invoke();
    }

    private void Lock(InputAction.CallbackContext context)
    {
        _CameraLocked = !_CameraLocked;
        if (context.performed)
            OnLock?.Invoke(_CameraLocked);
    }

    private void Choose(InputAction.CallbackContext context)
    {
        _ChooseHolded = !_ChooseHolded;
        if (context.performed)
            OnSelection?.Invoke(_ChooseHolded);
    }
}
