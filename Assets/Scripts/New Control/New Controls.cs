//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/New Controls.inputactions
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

namespace MyFlyBird
{
    public partial class @NewControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @NewControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""NewActionMap"",
            ""id"": ""21a30c4c-37e8-422e-868d-23b0f5aafb58"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""348733eb-5143-4e66-bb0d-21b9e6ed1f03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7791b381-c3ce-4a03-a160-250d2f311ca8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // NewActionMap
            m_NewActionMap = asset.FindActionMap("NewActionMap", throwIfNotFound: true);
            m_NewActionMap_Jump = m_NewActionMap.FindAction("Jump", throwIfNotFound: true);
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

        // NewActionMap
        private readonly InputActionMap m_NewActionMap;
        private INewActionMapActions m_NewActionMapActionsCallbackInterface;
        private readonly InputAction m_NewActionMap_Jump;
        public struct NewActionMapActions
        {
            private @NewControls m_Wrapper;
            public NewActionMapActions(@NewControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_NewActionMap_Jump;
            public InputActionMap Get() { return m_Wrapper.m_NewActionMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(NewActionMapActions set) { return set.Get(); }
            public void SetCallbacks(INewActionMapActions instance)
            {
                if (m_Wrapper.m_NewActionMapActionsCallbackInterface != null)
                {
                    @Jump.started -= m_Wrapper.m_NewActionMapActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_NewActionMapActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_NewActionMapActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_NewActionMapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public NewActionMapActions @NewActionMap => new NewActionMapActions(this);
        public interface INewActionMapActions
        {
            void OnJump(InputAction.CallbackContext context);
        }
    }
}