using Signals;
using Strategies.InputStrategy.Abstractions;
using UnityEngine.InputSystem;
using Zenject;

namespace Strategies.InputStrategy
{
    public class KeyboardInputStrategy : IInputStrategy
    {
        private readonly InputAction _moveAction;
        private readonly SignalBus _signalBus;

        public KeyboardInputStrategy(InputActionAsset inputAsset, SignalBus signalBus)
        {
            _signalBus = signalBus;
            _moveAction = inputAsset.FindActionMap("Player").FindAction("KeyboardMove");
        }

        public void Enable()
        {
            _moveAction.performed += OnPerformed;
            _moveAction.Enable();
        }

        public void Disable()
        {
            _moveAction.performed -= OnPerformed;
            _moveAction.Disable();
        }

        public void Dispose()
        {
            Disable();
        }

        private void OnPerformed(InputAction.CallbackContext ctx)
        {
            float direction = ctx.ReadValue<float>();
            _signalBus.Fire(new InputPerformedSignal(direction));
        }
    }
}