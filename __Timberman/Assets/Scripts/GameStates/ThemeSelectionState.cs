using Controllers;
using Definitions;
using GameStates.Abstraction;
using Systems;
using Zenject;

namespace GameStates
{
    public class ThemeSelectionSate : BaseGameSate
    {
        
        [Inject] private readonly GameplayController _gameplayController;
        
        public override void Enter(GameStateController stateController)
        {
            
        }

        public override void Update(GameStateController stateController)
        {
            
        }

        public override void Exit(GameStateController stateController)
        {
            _gameplayController.SendActivationRequest<InputSystem>(RequestMode.Activation);
        }
    }
}