using Controllers;
using Definitions;
using GameStates.Abstractions;
using Systems;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class PlayingState : BaseGameSate, IInitializable
    {
        public override void Enter()
        {
            Debug.Log("Entering Playing State");
            GameplayController.SendActivationRequest<TimerSystem>(true);
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