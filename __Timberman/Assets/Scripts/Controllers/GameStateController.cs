using System;
using GameStates;
using GameStates.Abstraction;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class GameStateController : MonoBehaviour
    {
        private BaseGameSate _currentSate;
        private GameplayController _gameplayController;
        
        [Inject] private readonly DiContainer _container;
        
        [Inject]
        public void Construct(GameplayController gameplayController)
        {
            _gameplayController = gameplayController;
        }

        private void Start()
        {
            _currentSate = _container.Resolve<ThemeSelectionSate>();
            _currentSate.Enter(this);
        }

        public void ChangeState(BaseGameSate baseGameSate)
        {
            _currentSate?.Exit(this);
            _currentSate = baseGameSate;
            _currentSate.Enter(this);
        }

        private void Update()
        {
            _currentSate.Update(this);
        }
    }
}