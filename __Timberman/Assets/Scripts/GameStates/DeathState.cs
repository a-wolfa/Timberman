using Controllers;
using GameStates.Abstraction;

namespace GameStates
{
    public class DeathState : BaseGameSate
    {
        public DeathState(GameplayController gameplayController, GameStateController stateController) 
            : base(gameplayController, stateController)
        { }

        public override void Enter(GameStateController stateController)
        {
            
        }

        public override void Update(GameStateController stateController)
        {
            
        }

        public override void Exit(GameStateController stateController)
        {
            
        }
    }
}