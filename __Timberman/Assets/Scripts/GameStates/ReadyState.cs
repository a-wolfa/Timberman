using Controllers;
using GameStates.Abstraction;
using Services;
using Signals;
using Systems;
using Zenject;

namespace GameStates
{
    public class ReadyState : IGameState
    {
        [Inject]
        private readonly SignalBus _signalBus;
        
        public void Enter(GameStateController stateController)
        {
            _signalBus.Fire<InputPerformedSignal>();
        }

        public void Update(GameStateController stateController)
        {
            
        }

        public void Exit(GameStateController stateController)
        {
            
        }
    }
}