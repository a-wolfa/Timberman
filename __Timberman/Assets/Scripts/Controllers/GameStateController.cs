using System;
using GameStates;
using GameStates.Abstraction;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class GameStateController : MonoBehaviour
    {
        private BaseGameState _currentState;
        
        private GameplayController _gameplayController;
        
        [Inject]
        public void Construct(GameplayController gameplayController)
        {
            _gameplayController = gameplayController;
        }

        private void Start()
        {
            _currentState = new ReadyState();
        }

        public void ChangeState(BaseGameState gameState)
        {
            _currentState?.Exit(this);
            _currentState = gameState;
            _currentState.Enter(this);
        }

        private void Update()
        {
            _currentState.Update(this);
        }
    }
}