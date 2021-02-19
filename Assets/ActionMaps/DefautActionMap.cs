// GENERATED AUTOMATICALLY FROM 'Assets/ActionMaps/DefautActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DefautActionMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefautActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefautActionMap"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""99f86eaa-a5b3-4fb5-91d2-000a2f0aea4c"",
            ""actions"": [
                {
                    ""name"": ""MoveOrAttack"",
                    ""type"": ""Button"",
                    ""id"": ""2e212310-ee7d-474c-9268-190a59fba8bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Choose"",
                    ""type"": ""Button"",
                    ""id"": ""15abe4b7-acb6-46c6-a3d5-9e0fb57a4f56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockCamera"",
                    ""type"": ""Button"",
                    ""id"": ""04035d1d-629c-4f86-bc62-0e259353f01e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""bd7bc679-e27c-456e-a85b-b5098e93e72b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""b4d5a58e-6f33-4ca6-918c-fea9127f1175"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dc43bf69-7284-4004-9283-0c42de0fc271"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveOrAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e09f6a8-ba42-4f03-8ce2-f1145f811cec"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Choose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d391dce-f2a2-4f6f-bfe6-540757a62182"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LockCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""467b6934-2741-4247-b9a0-4a228aa7fe35"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4dfa21ee-0cdd-461b-9bed-918e46a28db8"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MoveOrAttack = m_Gameplay.FindAction("MoveOrAttack", throwIfNotFound: true);
        m_Gameplay_Choose = m_Gameplay.FindAction("Choose", throwIfNotFound: true);
        m_Gameplay_LockCamera = m_Gameplay.FindAction("LockCamera", throwIfNotFound: true);
        m_Gameplay_MousePosition = m_Gameplay.FindAction("MousePosition", throwIfNotFound: true);
        m_Gameplay_MouseDelta = m_Gameplay.FindAction("MouseDelta", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_MoveOrAttack;
    private readonly InputAction m_Gameplay_Choose;
    private readonly InputAction m_Gameplay_LockCamera;
    private readonly InputAction m_Gameplay_MousePosition;
    private readonly InputAction m_Gameplay_MouseDelta;
    public struct GameplayActions
    {
        private @DefautActionMap m_Wrapper;
        public GameplayActions(@DefautActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveOrAttack => m_Wrapper.m_Gameplay_MoveOrAttack;
        public InputAction @Choose => m_Wrapper.m_Gameplay_Choose;
        public InputAction @LockCamera => m_Wrapper.m_Gameplay_LockCamera;
        public InputAction @MousePosition => m_Wrapper.m_Gameplay_MousePosition;
        public InputAction @MouseDelta => m_Wrapper.m_Gameplay_MouseDelta;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MoveOrAttack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveOrAttack;
                @MoveOrAttack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveOrAttack;
                @MoveOrAttack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveOrAttack;
                @Choose.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChoose;
                @Choose.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChoose;
                @Choose.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChoose;
                @LockCamera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLockCamera;
                @LockCamera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLockCamera;
                @LockCamera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLockCamera;
                @MousePosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MouseDelta.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseDelta;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveOrAttack.started += instance.OnMoveOrAttack;
                @MoveOrAttack.performed += instance.OnMoveOrAttack;
                @MoveOrAttack.canceled += instance.OnMoveOrAttack;
                @Choose.started += instance.OnChoose;
                @Choose.performed += instance.OnChoose;
                @Choose.canceled += instance.OnChoose;
                @LockCamera.started += instance.OnLockCamera;
                @LockCamera.performed += instance.OnLockCamera;
                @LockCamera.canceled += instance.OnLockCamera;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMoveOrAttack(InputAction.CallbackContext context);
        void OnChoose(InputAction.CallbackContext context);
        void OnLockCamera(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
    }
}
