using System;
using System.Linq;
using GameStates;
using GameStates.Abstraction;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class GameStateController : MonoBehaviour
    {
        private BaseGameSate[] _gameSates;
        
        private BaseGameSate _currentSate;
        
        [Inject] private readonly DiContainer _container;
        
        [Inject]
        public void Construct(BaseGameSate[] gameSates)
        {
            _gameSates = gameSates;
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
            Debug.Log(_currentSate);
            _currentSate.Update(this);
        }

        public BaseGameSate GetGameSate<TState>() where TState : BaseGameSate 
        {
            return _gameSates.FirstOrDefault(state => state is TState);
        }
    }
}