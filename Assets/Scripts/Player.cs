using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    public void OnMouse(InputValue context)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;

            agent.SetDestination(hit.point);
            Debug.Log(hit.point);
        }
    }

    public void OnKeyboard(InputValue context)
    {
        Debug.Log("Invoked Keyboard");
        Debug.Log(context);
    }
}
