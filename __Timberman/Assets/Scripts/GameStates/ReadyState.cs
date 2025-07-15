using Controllers;
using Definitions;
using GameStates.Abstraction;
using Signals;
using Systems;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class ReadySate : BaseGameSate
    {
        [Inject] private readonly SignalBus _signalBus;

        public ReadySate(GameplayController gameplayController, GameStateController gameStateController) 
            : base(gameplayController,  gameStateController)
        { }

        public override void Enter(GameStateController stateController)
        {
            _signalBus.Subscribe<InputPerformedSignal>(StartGame);
        }

        public override void Update(GameStateController stateController)
        { }

        public override void Exit(GameStateController stateController)
        { }

        private void StartGame()
        {
            _signalBus.Unsubscribe<InputPerformedSignal>(StartGame);
            GameplayController.SendActivationRequest<InputSystem>(RequestMode.Activation);
            StateController.ChangeState(StateController.GetGameSate<PlayingState>());
        }
    }
}