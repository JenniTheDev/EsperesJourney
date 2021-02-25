// GENERATED AUTOMATICALLY FROM 'Assets/InputActionMaps/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""1e65dc6a-55f2-4060-9dd1-bc587120b7cc"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6296fb5c-12e5-43be-9f3a-abdeb4039d3c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d1e98442-69bc-41c0-84a6-b3f60321b083"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""886817b5-e4b1-4e0c-a988-1e6ab1a31e28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Blink"",
                    ""type"": ""Button"",
                    ""id"": ""56836d0c-50b4-4394-9cf1-0ee6152eaf6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""cb3c1b1b-b054-442f-93c9-20da5f4fdc62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heal"",
                    ""type"": ""Button"",
                    ""id"": ""f5ad345c-bd59-4f5f-b08f-eb378b89e3c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability1"",
                    ""type"": ""Button"",
                    ""id"": ""365633cc-e1ea-4269-9d99-8a96ed4089fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability2"",
                    ""type"": ""Button"",
                    ""id"": ""a821e259-ba05-4170-8168-a2f1e0a0cb53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability3"",
                    ""type"": ""Button"",
                    ""id"": ""527bb598-bd0a-4aaa-9c05-28797ee5f196"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability4"",
                    ""type"": ""Button"",
                    ""id"": ""b0bd490e-aae6-4b10-a30e-39d31747f6ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cb2497ab-ffcb-4459-a96d-9ec01194ae26"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c7ddb3ca-655d-495c-a635-b8b4b2272f58"",
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
                    ""id"": ""83339b1b-49df-4a7e-8158-e96db5ee8505"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f847b422-ea0f-414f-9692-acb6d4fcafe7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d74d195b-7be8-4f50-aa6c-36781d9d25f3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2af3eaf0-5b45-47dd-bcac-0447325a5279"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""44a140e5-2698-49eb-91e2-57249a3ef85b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""794970ed-37df-4536-939d-cbaf5310337e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46610b44-0d82-4978-b512-b060c1b4df21"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""126cbb16-b79e-4022-b4c7-b1d80926f071"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88ae8797-dae5-4205-904c-a76b374f3565"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blink"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76cf0709-359e-4b98-9c6c-bb854963ff03"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blink"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53a6c293-0aac-4d13-8a3d-8e35127c8080"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97d37fee-ab1f-43cb-8468-8cd540e01c6c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""339ec742-bcbc-4db0-b28e-e97a06de1919"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1aa82236-3a25-4d82-98b8-1fbc737253e6"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23d4149c-deb3-46b5-bce5-34c5678cdf6b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""525a85e4-73a1-43e4-a828-123451b3843d"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51cbc9ca-e37a-4e3d-8ce6-a1888972d3cc"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ee72250-94ae-4cc5-807d-d4b5468951e2"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_Move = m_Character.FindAction("Move", throwIfNotFound: true);
        m_Character_Attack = m_Character.FindAction("Attack", throwIfNotFound: true);
        m_Character_Dash = m_Character.FindAction("Dash", throwIfNotFound: true);
        m_Character_Blink = m_Character.FindAction("Blink", throwIfNotFound: true);
        m_Character_Shoot = m_Character.FindAction("Shoot", throwIfNotFound: true);
        m_Character_Heal = m_Character.FindAction("Heal", throwIfNotFound: true);
        m_Character_Ability1 = m_Character.FindAction("Ability1", throwIfNotFound: true);
        m_Character_Ability2 = m_Character.FindAction("Ability2", throwIfNotFound: true);
        m_Character_Ability3 = m_Character.FindAction("Ability3", throwIfNotFound: true);
        m_Character_Ability4 = m_Character.FindAction("Ability4", throwIfNotFound: true);
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

    // Character
    private readonly InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private readonly InputAction m_Character_Move;
    private readonly InputAction m_Character_Attack;
    private readonly InputAction m_Character_Dash;
    private readonly InputAction m_Character_Blink;
    private readonly InputAction m_Character_Shoot;
    private readonly InputAction m_Character_Heal;
    private readonly InputAction m_Character_Ability1;
    private readonly InputAction m_Character_Ability2;
    private readonly InputAction m_Character_Ability3;
    private readonly InputAction m_Character_Ability4;
    public struct CharacterActions
    {
        private @Player m_Wrapper;
        public CharacterActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Character_Move;
        public InputAction @Attack => m_Wrapper.m_Character_Attack;
        public InputAction @Dash => m_Wrapper.m_Character_Dash;
        public InputAction @Blink => m_Wrapper.m_Character_Blink;
        public InputAction @Shoot => m_Wrapper.m_Character_Shoot;
        public InputAction @Heal => m_Wrapper.m_Character_Heal;
        public InputAction @Ability1 => m_Wrapper.m_Character_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_Character_Ability2;
        public InputAction @Ability3 => m_Wrapper.m_Character_Ability3;
        public InputAction @Ability4 => m_Wrapper.m_Character_Ability4;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAttack;
                @Dash.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDash;
                @Blink.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBlink;
                @Blink.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBlink;
                @Blink.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBlink;
                @Shoot.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                @Heal.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnHeal;
                @Heal.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnHeal;
                @Heal.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnHeal;
                @Ability1.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility1;
                @Ability1.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility1;
                @Ability1.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility1;
                @Ability2.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility2;
                @Ability2.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility2;
                @Ability2.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility2;
                @Ability3.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility3;
                @Ability3.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility3;
                @Ability3.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility3;
                @Ability4.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility4;
                @Ability4.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility4;
                @Ability4.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAbility4;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Blink.started += instance.OnBlink;
                @Blink.performed += instance.OnBlink;
                @Blink.canceled += instance.OnBlink;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Heal.started += instance.OnHeal;
                @Heal.performed += instance.OnHeal;
                @Heal.canceled += instance.OnHeal;
                @Ability1.started += instance.OnAbility1;
                @Ability1.performed += instance.OnAbility1;
                @Ability1.canceled += instance.OnAbility1;
                @Ability2.started += instance.OnAbility2;
                @Ability2.performed += instance.OnAbility2;
                @Ability2.canceled += instance.OnAbility2;
                @Ability3.started += instance.OnAbility3;
                @Ability3.performed += instance.OnAbility3;
                @Ability3.canceled += instance.OnAbility3;
                @Ability4.started += instance.OnAbility4;
                @Ability4.performed += instance.OnAbility4;
                @Ability4.canceled += instance.OnAbility4;
            }
        }
    }
    public CharacterActions @Character => new CharacterActions(this);
    public interface ICharacterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnBlink(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
        void OnAbility3(InputAction.CallbackContext context);
        void OnAbility4(InputAction.CallbackContext context);
    }
}
