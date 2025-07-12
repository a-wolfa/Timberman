using System;
using System.Timers;
using Blackboard;
using Definitions;
using Player;
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
        [Inject] private readonly TimerExpiredSignal _timerExpiredSignal;
        
        [SerializeField] private CollisionHandler collisionHandler;
        [SerializeField] private ThrowMode throwMode;

        public Side playerSide = Side.Left;
        

        private void Update()
        {
            _systemContainer.Update();
            _dataContainer.Update();
        }

        private void OnEnable()
        {
            _timerExpiredSignal.Subscribe(Die);
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
            collisionHandler.Die();
        }

        public IThrow GetThrowStrategy()
        {
            return _throwResolver.ResolveThrowType(throwMode);
        }
    }
}