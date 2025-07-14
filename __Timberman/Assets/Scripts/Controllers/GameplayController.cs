using System;
using System.Timers;
using Blackboard;
using Definitions;
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
            _signalBus.Subscribe<PlayerCreatedSignal>(OnPlayerCreate);
        }

        public void SendActivationRequest<TSystem>(RequestMode request)  where TSystem : BaseSystem
        {
            if (request is RequestMode.Activation) 
                _systemContainer.RequestToActivateSystem<TSystem>();
            else if (request is RequestMode.Deactivation)
                _systemContainer.RequestToDeactivateSystem<TSystem>();
        }

        private void Die()
        {
            _collisionHandler.Die();
        }

        public IThrow GetThrowStrategy()
        {
            return _throwResolver.ResolveThrowType(throwMode);
        }

        private void OnPlayerCreate(PlayerCreatedSignal signal)
        {
            _collisionHandler = signal.Player.GetComponent<CollisionHandler>();
        }
    }
}