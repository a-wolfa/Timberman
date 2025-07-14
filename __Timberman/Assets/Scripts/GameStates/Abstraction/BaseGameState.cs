using Controllers;
using UnityEngine;
using Zenject;

namespace GameStates.Abstraction
{
    public abstract class BaseGameSate
    {
        protected readonly GameplayController GameplayController;
        protected readonly GameStateController StateController;

        protected BaseGameSate(GameplayController gameplayController, GameStateController stateController)
        {
            GameplayController = gameplayController;
            StateController = stateController;
        }

        public abstract void Enter(GameStateController stateController);
        
        public abstract void Update(GameStateController stateController);
        
        public abstract void Exit(GameStateController stateController);
    }
}
