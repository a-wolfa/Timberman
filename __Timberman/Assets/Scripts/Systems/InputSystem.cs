using Definitions;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Systems
{
    public class InputSystem : BaseSystem
    {
        private readonly InputData _inputData;
        private readonly InputAction _chopInput;

        private float _chopDirection;
        
        public InputSystem(InputData inputData, InputActionAsset inputAsset)
        {
            _inputData = inputData;
            
            var playerInputMap = inputAsset.FindActionMap("Player");
            _chopInput = playerInputMap.FindAction("Move");

            _chopInput.performed += OnChopInputPressed;
            
            _chopInput.Enable();
        }

        public override void Update()
        {
            if (_chopDirection == 0)
                return;
            
            _inputData.ChopDirection = (int)_chopDirection;
            _chopDirection = 0;
        }

        private void OnChopInputPressed(InputAction.CallbackContext context)
        {
            _chopDirection = context.ReadValue<float>();
        }
    }
}
