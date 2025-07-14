using Controllers;
using Definitions;
using GameStates.Abstraction;
using Signals;
using Systems;
using Zenject;

namespace GameStates
{
    public class ReadySate : BaseGameSate
    {
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly GameStateController _gameStateController;
        [Inject] private readonly GameplayController _gameplayController;

        public void Init()
        {
            _signalBus.Subscribe<InputPerformedSignal>(StartGame);
        }

        public override void Enter(GameStateController stateController)
        { }

        public override void Update(GameStateController stateController)
        { }

        public override void Exit(GameStateController stateController)
        { }

        private void StartGame()
        {
            _gameplayController.SendActivationRequest<TimerSystem>(RequestMode.Activation);
            _signalBus.Unsubscribe<InputPerformedSignal>(StartGame);
        }
    }
}