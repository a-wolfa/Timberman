using Consts;
using Signals;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class AnimationSystem : BaseSystem
    {
        private readonly InputData _inputData;
        private readonly SignalBus _signalBus;
        
        private  Animator _animator;
        
        
        public AnimationSystem(InputData inputData, SignalBus signalBus)
        {
            _inputData =  inputData;
            _signalBus = signalBus;
        }

        public void Init()
        {
            _signalBus.Subscribe<PlayerCreatedSignal>(OnPlayerCreated);
        }
        
        public override void Update()
        {
            _animator?.SetInteger(AnimNames.PlayerChopAnimation, _inputData.ChopDirection);
        }

        private void OnPlayerCreated(PlayerCreatedSignal signal)
        {
            _animator = signal.Player.GetComponentInChildren<Animator>();
            Debug.Log($"Player created: {_animator}");
        }
    }
}
