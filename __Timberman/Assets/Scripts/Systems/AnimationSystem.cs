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

        private int _parameterID;
        
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
            _animator?.SetInteger(_parameterID, _inputData.ChopDirection);
        }

        private void OnPlayerCreated(PlayerCreatedSignal signal)
        {
            _animator = signal.Player.GetComponentInChildren<Animator>();
            _parameterID = Animator.StringToHash(AnimNames.PlayerChopAnimation);
        }
    }
}
