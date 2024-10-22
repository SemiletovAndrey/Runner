//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Runner/Scripts/Player/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""GameplayInput"",
            ""id"": ""af6dd929-d297-4362-8164-315d413b54e6"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""1f63f7d7-ff23-49ee-af64-e58162c6c02a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PC"",
                    ""type"": ""Value"",
                    ""id"": ""0b84e1bc-e6b3-4c2e-852d-4f1e83398b14"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""27eaa61f-7c3f-4e5a-a278-a599c11774fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d57738a8-eb81-4379-b21d-a585cf7c74be"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""75fec664-cb8e-4e7f-8ca1-ecca0a15e973"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""33904ad3-58ae-4345-b9b2-9c951dc1af37"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c4fd69f7-9eaa-4c9e-a29e-9c4a1dc2f606"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9965c649-6b33-49e2-b5c7-00d7f42f264c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""395d4aed-666a-43bd-9b5f-79073883f5ab"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d75c8846-0b15-4259-aae3-b97f4c3409ec"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1eae293c-c7b0-42f5-aec3-fd955d820c14"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""453fcd3f-e460-4365-9abd-6623d6bcfccc"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""816bca93-5346-4209-b869-262bc57f3c74"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8f1f995f-d4c1-413f-bed3-4e830b5b2964"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ff37b7c-30b9-44d7-8d3f-42e7b89d8b95"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameplayInput
        m_GameplayInput = asset.FindActionMap("GameplayInput", throwIfNotFound: true);
        m_GameplayInput_Position = m_GameplayInput.FindAction("Position", throwIfNotFound: true);
        m_GameplayInput_PC = m_GameplayInput.FindAction("PC", throwIfNotFound: true);
        m_GameplayInput_Press = m_GameplayInput.FindAction("Press", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GameplayInput
    private readonly InputActionMap m_GameplayInput;
    private List<IGameplayInputActions> m_GameplayInputActionsCallbackInterfaces = new List<IGameplayInputActions>();
    private readonly InputAction m_GameplayInput_Position;
    private readonly InputAction m_GameplayInput_PC;
    private readonly InputAction m_GameplayInput_Press;
    public struct GameplayInputActions
    {
        private @PlayerInput m_Wrapper;
        public GameplayInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_GameplayInput_Position;
        public InputAction @PC => m_Wrapper.m_GameplayInput_PC;
        public InputAction @Press => m_Wrapper.m_GameplayInput_Press;
        public InputActionMap Get() { return m_Wrapper.m_GameplayInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayInputActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayInputActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayInputActionsCallbackInterfaces.Add(instance);
            @Position.started += instance.OnPosition;
            @Position.performed += instance.OnPosition;
            @Position.canceled += instance.OnPosition;
            @PC.started += instance.OnPC;
            @PC.performed += instance.OnPC;
            @PC.canceled += instance.OnPC;
            @Press.started += instance.OnPress;
            @Press.performed += instance.OnPress;
            @Press.canceled += instance.OnPress;
        }

        private void UnregisterCallbacks(IGameplayInputActions instance)
        {
            @Position.started -= instance.OnPosition;
            @Position.performed -= instance.OnPosition;
            @Position.canceled -= instance.OnPosition;
            @PC.started -= instance.OnPC;
            @PC.performed -= instance.OnPC;
            @PC.canceled -= instance.OnPC;
            @Press.started -= instance.OnPress;
            @Press.performed -= instance.OnPress;
            @Press.canceled -= instance.OnPress;
        }

        public void RemoveCallbacks(IGameplayInputActions instance)
        {
            if (m_Wrapper.m_GameplayInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayInputActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayInputActions @GameplayInput => new GameplayInputActions(this);
    public interface IGameplayInputActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnPC(InputAction.CallbackContext context);
        void OnPress(InputAction.CallbackContext context);
    }
}