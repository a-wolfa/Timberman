using Controllers;
using Definitions;
using GameStates.Abstraction;
using Systems;

namespace GameStates
{
    public class PlayingState : BaseGameSate
    {
        public PlayingState(GameplayController gameplayController, GameStateController gameStateController) 
            : base(gameplayController,  gameStateController)
        { }

        public override void Enter(GameStateController stateController)
        {
            GameplayController.SendActivationRequest<TimerSystem>(RequestMode.Activation);
        }

        public override void Update(GameStateController stateController)
        {
            
        }

        public override void Exit(GameStateController stateController)
        {
            
        }
    }
}