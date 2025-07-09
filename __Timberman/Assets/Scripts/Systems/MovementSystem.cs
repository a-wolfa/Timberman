using Definitions;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems
{
    public class MovementSystem : BaseSystem
    {
        private readonly InputData _inputData;
        private Side _currentSide = Side.Left;
        
        private GameObject _player;

        public MovementSystem(InputData inputData, GameObject player)
        {
            _inputData = inputData;
            _player = player;
            
        }
        public override void Update()
        {
            var chopInput = _inputData.ChopDirection;
         
            if (chopInput == 0)
                return;
            
            Move(chopInput);
        }

        private void Move(int  direction)
        {
            if (direction == (int)_currentSide)
                return;
            
            _currentSide = (Side)direction;
            
            var position = _player.transform.position;
            position.x = -position.x;
            _player.transform.position = position;
            
            var scale = _player.transform.localScale;
            scale.x = -scale.x;
            _player.transform.localScale = scale;
        }
    }
}
