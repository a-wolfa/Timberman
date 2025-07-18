using GameStates.Abstractions;
using Signals;
using Systems;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class ReadySate : BaseGameSate
    {
        public override void Enter()
        {
            SignalBus.Subscribe<InputPerformedSignal>(StartGame);
            GameplayController.SendActivationRequest<AnimationSystem>(true);
            GameplayController.SendActivationRequest<MovementSystem>(true);
            GameplayController.SendActivationRequest<TreeManagementSystem>(true);
        }

        public override void Update()
        { }

        public override void Exit()
        {
            SignalBus.Unsubscribe<InputPerformedSignal>(StartGame);
        }

        private void StartGame()
        {
            GameplayController.SendActivationRequest<InputSystem>(true);
            GameStateController.ChangeState<PlayingState>();
        }
    }
}