// GENERATED AUTOMATICALLY FROM 'Assets/ActionMaps/CameraMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CameraMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CameraMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraMap"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""e1e41c3b-ac54-4b61-9096-e112f3ab3dbf"",
            ""actions"": [
                {
                    ""name"": ""MoveTo"",
                    ""type"": ""Button"",
                    ""id"": ""fa7512e1-30ed-4c14-bcea-38cce4662c12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lock"",
                    ""type"": ""Button"",
                    ""id"": ""673d65e5-7612-44d2-8d9a-cc76577ebd92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""368da7ea-3686-483e-a50a-9a1196af61ad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delta"",
                    ""type"": ""Value"",
                    ""id"": ""11be5b44-ba4b-4e03-851d-58f97b233125"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6673c6f3-6b12-45d0-89de-a9ba3e19ddc1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e14b09e1-878f-45e5-91da-262b10b8b187"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""596b7c01-2b01-4314-a435-3f2bf3b8b791"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a7df449-bdbe-4549-bcb6-ee597f274b36"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MoveTo = m_Gameplay.FindAction("MoveTo", throwIfNotFound: true);
        m_Gameplay_Lock = m_Gameplay.FindAction("Lock", throwIfNotFound: true);
        m_Gameplay_Position = m_Gameplay.FindAction("Position", throwIfNotFound: true);
        m_Gameplay_Delta = m_Gameplay.FindAction("Delta", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_MoveTo;
    private readonly InputAction m_Gameplay_Lock;
    private readonly InputAction m_Gameplay_Position;
    private readonly InputAction m_Gameplay_Delta;
    public struct GameplayActions
    {
        private @CameraMap m_Wrapper;
        public GameplayActions(@CameraMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveTo => m_Wrapper.m_Gameplay_MoveTo;
        public InputAction @Lock => m_Wrapper.m_Gameplay_Lock;
        public InputAction @Position => m_Wrapper.m_Gameplay_Position;
        public InputAction @Delta => m_Wrapper.m_Gameplay_Delta;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MoveTo.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveTo;
                @MoveTo.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveTo;
                @MoveTo.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveTo;
                @Lock.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLock;
                @Lock.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLock;
                @Lock.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLock;
                @Position.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                @Delta.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDelta;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveTo.started += instance.OnMoveTo;
                @MoveTo.performed += instance.OnMoveTo;
                @MoveTo.canceled += instance.OnMoveTo;
                @Lock.started += instance.OnLock;
                @Lock.performed += instance.OnLock;
                @Lock.canceled += instance.OnLock;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMoveTo(InputAction.CallbackContext context);
        void OnLock(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnDelta(InputAction.CallbackContext context);
    }
}
