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
        [Inject] private readonly ThrowResolver _throwResolver;
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly GameStateController _gameStateController;
        
        [SerializeField] ThrowMode throwMode;
        
        public IThrow ThrowStrategy;
        
        public Side PlayerSide { get; set; } = Side.Left;


        private void Awake()
        {
            ThrowStrategy = GetThrowStrategy();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<ThemeSelectedSignal>(OnThemeSelected);
            _signalBus.Subscribe<SegmentChoppedSignal>(OnChopAnimationEvent);
        }
        
        private void OnDisable()
        {
            _signalBus.Unsubscribe<ThemeSelectedSignal>(OnThemeSelected);
            _signalBus.Unsubscribe<SegmentChoppedSignal>(OnChopAnimationEvent);
        }
        
        private void Update()
        {
            _systemContainer.Update();
            _dataContainer.Update();
        }
        
        public IThrow GetThrowStrategy()
        {
            return _throwResolver.ResolveThrowType(throwMode);
        }
        
        public void SendActivationRequest<TSystem>(bool isActive)  where TSystem : BaseSystem
        {
            if (isActive)
            {
                _systemContainer.RequestActivation<TSystem>();
            }
            else
            {
                _systemContainer.RequestDeactivation<TSystem>();
            }
        }

        private void OnThemeSelected()
        {
            _gameStateController.ChangeState<ReadySate>();
        }
        
        private void OnChopAnimationEvent()
        {
            SendActivationRequest<ChoppingSystem>(true);
        }
    }
}