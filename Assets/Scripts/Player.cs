using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Camera playerCamera;

    public void MoveTo(Vector3 destination) => agent.SetDestination(destination);
    
    public void OnKeyboard(InputValue context)
    {
        Debug.Log("Invoked Keyboard");
        Debug.Log(context);
    }
}
