using System;
using System.Timers;
using Blackboard;
using Definitions;
using Player;
using Signals;
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
        
        [Inject] private readonly TimerExpiredSignal _timerExpiredSignal;
        
        [SerializeField] private CollisionHandler collisionHandler;

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

        public void Die()
        {
            collisionHandler.Die();
        }
    }
}