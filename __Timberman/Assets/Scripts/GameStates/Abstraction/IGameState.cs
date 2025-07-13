using Controllers;
using UnityEngine;

namespace GameStates.Abstraction
{
    public interface IGameState
    {
        void Enter(GameStateController stateController);
        
        void Update(GameStateController stateController);
        
        void Exit(GameStateController stateController);
    }
}
