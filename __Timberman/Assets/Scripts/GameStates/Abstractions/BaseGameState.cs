using Controllers;
using Zenject;

namespace GameStates.Abstractions
{
    public abstract class BaseGameSate
    {
        [Inject] protected readonly SignalBus SignalBus;
        [Inject] protected readonly GameStateController GameStateController;
        [Inject] protected readonly GameplayController GameplayController;

        public abstract void Enter();
        
        public abstract void Update();
        
        public abstract void Exit();

        public abstract void OnEventChangeState();
        
    }
}
