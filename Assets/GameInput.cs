// GENERATED AUTOMATICALLY FROM 'Assets/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""MonsterControll"",
            ""id"": ""091b258b-c52a-47d9-94b8-4b34c43ccebd"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""5dd99a8b-79f4-44b0-b91d-9e0d280882f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2832f7dc-7196-45c7-8fd8-a46c17999d9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Climb"",
                    ""type"": ""Button"",
                    ""id"": ""2cb18c89-74cd-4d5d-beb3-9cea86051bf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1251964b-fdc3-414a-af6e-735a97d688f8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""bb39ef89-ed46-4cad-8b38-3f6ddadb98cf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a59170bb-53bb-4d67-82ea-c2f8aef17b3f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c3255cd3-9f99-46f5-ab90-6438acbf85dc"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6116d171-c028-44ba-88e4-70f33bd64f82"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0f7c69d8-a82a-44f3-b7d5-01ce51a881b1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Common"",
            ""id"": ""317ba88a-990c-415f-affb-e069acf328a8"",
            ""actions"": [
                {
                    ""name"": ""Inactive"",
                    ""type"": ""Button"",
                    ""id"": ""403a0cde-d74e-48f7-ab2a-4f89c44c19dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Talk"",
                    ""type"": ""Button"",
                    ""id"": ""54541694-6ff5-40ac-b8a6-da6855911511"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8ad234cf-caf6-48cb-b28d-a187464ad9df"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inactive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1e1684d-1851-4ecf-aca7-743fe596dd3e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Talk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MonsterControll
        m_MonsterControll = asset.FindActionMap("MonsterControll", throwIfNotFound: true);
        m_MonsterControll_Move = m_MonsterControll.FindAction("Move", throwIfNotFound: true);
        m_MonsterControll_Jump = m_MonsterControll.FindAction("Jump", throwIfNotFound: true);
        m_MonsterControll_Climb = m_MonsterControll.FindAction("Climb", throwIfNotFound: true);
        // Common
        m_Common = asset.FindActionMap("Common", throwIfNotFound: true);
        m_Common_Inactive = m_Common.FindAction("Inactive", throwIfNotFound: true);
        m_Common_Talk = m_Common.FindAction("Talk", throwIfNotFound: true);
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

    // MonsterControll
    private readonly InputActionMap m_MonsterControll;
    private IMonsterControllActions m_MonsterControllActionsCallbackInterface;
    private readonly InputAction m_MonsterControll_Move;
    private readonly InputAction m_MonsterControll_Jump;
    private readonly InputAction m_MonsterControll_Climb;
    public struct MonsterControllActions
    {
        private @GameInput m_Wrapper;
        public MonsterControllActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MonsterControll_Move;
        public InputAction @Jump => m_Wrapper.m_MonsterControll_Jump;
        public InputAction @Climb => m_Wrapper.m_MonsterControll_Climb;
        public InputActionMap Get() { return m_Wrapper.m_MonsterControll; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MonsterControllActions set) { return set.Get(); }
        public void SetCallbacks(IMonsterControllActions instance)
        {
            if (m_Wrapper.m_MonsterControllActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MonsterControllActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MonsterControllActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MonsterControllActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_MonsterControllActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MonsterControllActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MonsterControllActionsCallbackInterface.OnJump;
                @Climb.started -= m_Wrapper.m_MonsterControllActionsCallbackInterface.OnClimb;
                @Climb.performed -= m_Wrapper.m_MonsterControllActionsCallbackInterface.OnClimb;
                @Climb.canceled -= m_Wrapper.m_MonsterControllActionsCallbackInterface.OnClimb;
            }
            m_Wrapper.m_MonsterControllActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Climb.started += instance.OnClimb;
                @Climb.performed += instance.OnClimb;
                @Climb.canceled += instance.OnClimb;
            }
        }
    }
    public MonsterControllActions @MonsterControll => new MonsterControllActions(this);

    // Common
    private readonly InputActionMap m_Common;
    private ICommonActions m_CommonActionsCallbackInterface;
    private readonly InputAction m_Common_Inactive;
    private readonly InputAction m_Common_Talk;
    public struct CommonActions
    {
        private @GameInput m_Wrapper;
        public CommonActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Inactive => m_Wrapper.m_Common_Inactive;
        public InputAction @Talk => m_Wrapper.m_Common_Talk;
        public InputActionMap Get() { return m_Wrapper.m_Common; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CommonActions set) { return set.Get(); }
        public void SetCallbacks(ICommonActions instance)
        {
            if (m_Wrapper.m_CommonActionsCallbackInterface != null)
            {
                @Inactive.started -= m_Wrapper.m_CommonActionsCallbackInterface.OnInactive;
                @Inactive.performed -= m_Wrapper.m_CommonActionsCallbackInterface.OnInactive;
                @Inactive.canceled -= m_Wrapper.m_CommonActionsCallbackInterface.OnInactive;
                @Talk.started -= m_Wrapper.m_CommonActionsCallbackInterface.OnTalk;
                @Talk.performed -= m_Wrapper.m_CommonActionsCallbackInterface.OnTalk;
                @Talk.canceled -= m_Wrapper.m_CommonActionsCallbackInterface.OnTalk;
            }
            m_Wrapper.m_CommonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Inactive.started += instance.OnInactive;
                @Inactive.performed += instance.OnInactive;
                @Inactive.canceled += instance.OnInactive;
                @Talk.started += instance.OnTalk;
                @Talk.performed += instance.OnTalk;
                @Talk.canceled += instance.OnTalk;
            }
        }
    }
    public CommonActions @Common => new CommonActions(this);
    public interface IMonsterControllActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnClimb(InputAction.CallbackContext context);
    }
    public interface ICommonActions
    {
        void OnInactive(InputAction.CallbackContext context);
        void OnTalk(InputAction.CallbackContext context);
    }
}
