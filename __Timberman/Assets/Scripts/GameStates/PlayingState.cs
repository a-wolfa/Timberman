using Controllers;
using Definitions;
using GameStates.Abstractions;
using Systems;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class PlayingState : BaseGameSate
    {
        public override void Enter()
        {
            GameplayController.SendActivationRequest<TimerSystem>(true);
        }

        public override void Update()
        { }

        public override void Exit()
        { }
    }
}