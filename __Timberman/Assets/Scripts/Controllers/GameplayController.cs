using System;
using System.Timers;
using Blackboard;
using Definitions;
using GameStates;
using Handlers;
using Resolvers;
using Signals;
using Strategies.ThrowStrategies.Abstractions;
using Systems;
using Systems.Abstractions;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class GameplayController : MonoBehaviour
    {
        [Inject] private readonly SystemContainer _systemContainer;
        [Inject] private readonly DataContainer _dataContainer;
        [Inject] ThrowResolver _throwResolver;
        [Inject] private readonly SignalBus _signalBus;
        [Inject] GameStateController _gameStateController;
        
        [SerializeField] private ThrowMode throwMode;

        private CollisionHandler _collisionHandler;
        
        public Side playerSide = Side.Left;
        public Theme theme = Theme.Spring;
        
        private void Update()
        {
            _systemContainer.Update();
            _dataContainer.Update();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<TimerExpiredSignal>(Die);
            _signalBus.Subscribe<PlayerCreatedSignal>(OnPlayerCreated);
            _signalBus.Subscribe<ThemeSelectedSignal>(OnThemeSelected);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<TimerExpiredSignal>(Die);
            _signalBus.Unsubscribe<PlayerCreatedSignal>(OnPlayerCreated);
            _signalBus.Unsubscribe<ThemeSelectedSignal>(OnThemeSelected);
        }

        public void SendActivationRequest<TSystem>(RequestMode request)  where TSystem : BaseSystem
        {
            switch (request)
            {
                case RequestMode.Activation:
                    
                    break;
                case RequestMode.Deactivation:
                    break;
                default:
                    break;
            }
        }

        private void Die()
        {
            _collisionHandler?.Die();
        }

        public IThrow GetThrowStrategy()
        {
            return _throwResolver.ResolveThrowType(throwMode);
        }

        private void OnPlayerCreated(PlayerCreatedSignal signal)
        {
            _collisionHandler = signal.Player.GetComponent<CollisionHandler>();
        }

        private void OnThemeSelected()
        {
            _gameStateController.ChangeState(_gameStateController.GetGameSate<ReadySate>());
        }
    }
}