using Consts;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;

namespace Systems
{
    public class AnimationSystem : BaseSystem
    {
        private readonly InputData _inputData;
        private readonly Animator _animator;
        
        public AnimationSystem(InputData inputData, Animator animator)
        {
            _inputData =  inputData;
            _animator = animator;
        }
        
        public override void Update()
        {
            Debug.Log(_animator);
            _animator.SetInteger(AnimNames.PlayerChopAnimation, _inputData.ChopDirection);
        }
    }
}
