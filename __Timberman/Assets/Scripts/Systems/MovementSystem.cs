using Definitions;
using Handlers.Player;
using Signals;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Systems
{
    public class MovementSystem : BaseSystem
    {
        private readonly InputData _inputData;
        private readonly MovementData _movementData;
        private readonly SignalBus _signalBus;
        
        private GameObject _player;

        public MovementSystem(
            InputData inputData, 
            MovementData movementData,
            SignalBus signalBus
            )
        {
            _inputData = inputData;
            _movementData = movementData;
            _signalBus = signalBus;
        }

        public void Init()
        {
            _signalBus.Subscribe<PlayerCreatedSignal>(OnPlayerCreated);
        }
        
        public override void Update()
        {
            var chopInput = _inputData.ChopDirection;
            Debug.Log("Chop Direction: " + chopInput);
            if (chopInput == 0)
                return;
            
            Move(chopInput);
            _movementData.CurrentSide = (Side)chopInput;
        }

        private void Move(int chopInput)
        {
            if (chopInput == (int) _movementData.CurrentSide)
                return;
            
            var position = _player.transform.position;
            position.x = -position.x;
            _player.transform.position = position;
            
            var scale = _player.transform.localScale;
            scale.x = -scale.x;
            _player.transform.localScale = scale;
        }

        private void OnPlayerCreated(PlayerCreatedSignal playerCreatedSignal)
        {
            _player = playerCreatedSignal.Player;
        }
    }
}
