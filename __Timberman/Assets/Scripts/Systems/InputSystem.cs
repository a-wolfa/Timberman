using System;
using Signals;
using Systems.Abstractions;
using Systems.Data;
using Strategies.InputStrategy.Abstractions;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class InputSystem : BaseSystem, IDisposable
    {
        private readonly InputData _inputData;
        private readonly SignalBus _signalBus;
        private readonly IInputStrategy _inputStrategy;

        private float _pendingDirection;

        public InputSystem(InputData inputData, SignalBus signalBus, IInputStrategy inputStrategy)
        {
            _inputData = inputData;
            _signalBus = signalBus;
            _inputStrategy = inputStrategy;
        }

        public void Init()
        {
            _signalBus.Subscribe<InputPerformedSignal>(OnInputPerformed);
            _inputStrategy.Enable();
        }

        private void OnInputPerformed(InputPerformedSignal signal)
        {
            _pendingDirection = (int)signal.Direction;
        }

        public override void Update()
        {
            if (_pendingDirection == 0)
                return;
            
            _inputData.ChopDirection = (int)_pendingDirection;

            _pendingDirection = 0;
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<InputPerformedSignal>(OnInputPerformed);
            _inputStrategy.Disable();
        }
    }
}