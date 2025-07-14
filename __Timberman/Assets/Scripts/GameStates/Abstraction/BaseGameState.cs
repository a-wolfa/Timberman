using Controllers;
using UnityEngine;
using Zenject;

namespace GameStates.Abstraction
{
    public abstract class BaseGameSate
    {
        public abstract void Enter(GameStateController stateController);
        
        public abstract void Update(GameStateController stateController);
        
        public abstract void Exit(GameStateController stateController);
    }
}
