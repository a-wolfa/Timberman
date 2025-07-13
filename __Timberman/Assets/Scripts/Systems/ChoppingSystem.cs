using Components;
using Controllers;
using Definitions;
using DG.Tweening;
using Extensions;
using Signals;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class ChoppingSystem : BaseSystem
    {
        private Transform _treeRoot;
        
        private readonly TreeData _treeData;
        private readonly MovementData _movementData;
        
        GameplayController _gameplayController;
        private readonly SegmentChoppedSignal _segmentChoppedSignal;
        
        private TreeSegment _bottomSegment;
        
        private Rigidbody2D _rb2D;

        public ChoppingSystem(TreeData treeData,
            GameplayController gameplayController,
            SegmentChoppedSignal segmentChoppedSignal,
            [Inject(Id = "Root")] Transform treeRoot,
            MovementData movementData)
        {
            _treeData = treeData;
            _movementData = movementData;
            _gameplayController = gameplayController;
            _segmentChoppedSignal = segmentChoppedSignal;
            _treeRoot = treeRoot;
        }

        public override void Update()
        {
            _bottomSegment = _treeData.Segments[0];
            _bottomSegment.transform.SetParent(null);
            _treeData.Segments.RemoveAt(0);
            
            _gameplayController.playerSide = _movementData.CurrentSide;
            
            var throwStrategy =  _gameplayController.GetThrowStrategy();
            throwStrategy.Throw(_bottomSegment, _movementData.CurrentSide);
            
            _segmentChoppedSignal.Fire();
            _treeData.ShouldMoveTree = true;
            
            _gameplayController.SendActivationRequest<ChoppingSystem>(RequestMode.Deactivation);
        }
    }
}
