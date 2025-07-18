using GameStates.Abstractions;
using Systems;
using UnityEngine;
using Zenject;
using InputSystem = Systems.InputSystem;

namespace GameStates
{
    public class DeathState : BaseGameSate, IInitializable
    {
        public override void Enter()
        {
            Debug.Log("Entering Death State");
            GameplayController.SendActivationRequest<InputSystem>(false);
            GameplayController.SendActivationRequest<TimerSystem>(false);
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override void OnEventChangeState()
        {
            
        }

        public void Initialize()
        {
            
        }
    }
}