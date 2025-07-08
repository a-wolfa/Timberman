using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Systems
{
    public class InputSystem : BaseSystem
    {
        private InputData _inputData;
        
        public InputSystem(InputData inputData, InputActionAsset inputAsset)
        {
            _inputData = inputData;
            
            var playerInputMap = inputAsset.FindActionMap("Player");
            var chopLeft = playerInputMap.FindAction("Chop Left");
            var chopRight = playerInputMap.FindAction("Chop Right");

            chopLeft.performed += OnChopPressed;
            chopRight.performed += OnChopPressed;
            
            chopLeft.Enable();
            chopRight.Enable();
        }

        public override void Update()
        {
        }

        public void OnChopPressed(InputAction.CallbackContext ctx)
        {
            _inputData.ChopInput = ctx.action;
        }
    }
}
