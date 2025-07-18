using System;
using System.Linq;
using GameStates;
using GameStates.Abstractions;
using Signals;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class GameStateController : MonoBehaviour
    {
        private BaseGameSate[] _gameSates;
        private BaseGameSate _currentSate;
        
        [Inject] SignalBus _signalBus;
        
        [Inject]
        public void Construct(BaseGameSate[] gameSates)
        {
            _gameSates = gameSates;
            _currentSate = GetGameSate<ThemeSelectionSate>();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDiedSignal);
            _signalBus.Subscribe<TimerExpiredSignal>(OnPlayerDiedSignal);
            _currentSate.Enter();
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDiedSignal);
            _signalBus.Unsubscribe<TimerExpiredSignal>(OnPlayerDiedSignal);
        }

        public void ChangeState<TGameState>() where TGameState : BaseGameSate
        {
            var gameState = GetGameSate<TGameState>();
            _currentSate?.Exit();
            _currentSate = gameState;
            _currentSate.Enter();
        }

        private void Update()
        {
            _currentSate.Update();
        }

        private BaseGameSate GetGameSate<TState>() where TState : BaseGameSate 
        {
            return _gameSates.FirstOrDefault(state => state is TState);
        }

        private void OnPlayerDiedSignal()
        {
            ChangeState<DeathState>();
        }
    }
}