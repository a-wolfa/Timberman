using Controllers;
using UnityEngine;

namespace GameStates.Abstraction
{
    public abstract class BaseGameState
    {
        public abstract void Enter(GameStateController stateController);
        
        public abstract void Update(GameStateController stateController);
        
        public abstract void Exit(GameStateController stateController);
    }
}
