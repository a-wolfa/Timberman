using GameStates.Abstractions;
using Systems;
using UnityEngine;
using Zenject;
using InputSystem = Systems.InputSystem;

namespace GameStates
{
    public class DeathState : BaseGameSate
    {
        public override void Enter()
        {
            GameplayController.SendActivationRequest<InputSystem>(false);
            GameplayController.SendActivationRequest<TimerSystem>(false);
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}