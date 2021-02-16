using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public void OnMouse(InputValue context)
    {
        Debug.Log("Invoked Mouse");
        Debug.Log(context);
    }
    
    public void OnMouse(InputAction.CallbackContext context)
    {
        Debug.Log("Invoked Mouse");
        Debug.Log(context);
    }
    
    public void OnKeyboard(InputValue context)
    {
        Debug.Log("Invoked Mouse");
        Debug.Log(context);
    }
    
    public void OnKeyboard(InputAction.CallbackContext context)
    {
        Debug.Log("Invoked Mouse");
        Debug.Log(context);
    }
}
