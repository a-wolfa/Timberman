using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Strategies.InputStrategy.Abstractions;
using Signals;

namespace Strategies.InputStrategy
{
    public class TouchInputStrategy : IInputStrategy
    {
        private readonly InputAction _touchTapAction;
        private readonly InputAction _touchPositionAction;
        private readonly SignalBus _signalBus;

        public TouchInputStrategy(InputActionAsset inputAsset, SignalBus signalBus)
        {
            var map = inputAsset.FindActionMap("Player");
            _touchTapAction = map.FindAction("TouchTap");
            _touchPositionAction = map.FindAction("TouchPosition"); // You’ll need this too

            _signalBus = signalBus;
        }

        public void Enable()
        {
            _touchTapAction.performed += OnTap;
            _touchTapAction.Enable();
            _touchPositionAction.Enable();
        }

        public void Disable()
        {
            _touchTapAction.performed -= OnTap;
            _touchTapAction.Disable();
            _touchPositionAction.Disable();
        }

        public void Dispose()
        {
            Disable();
        }

        private void OnTap(InputAction.CallbackContext context)
        {
            Vector2 pos = _touchPositionAction.ReadValue<Vector2>();
            float dir = pos.x < Screen.width / 2f ? -1f : 1f;

            _signalBus.Fire(new InputPerformedSignal(dir));
        }
    }
}