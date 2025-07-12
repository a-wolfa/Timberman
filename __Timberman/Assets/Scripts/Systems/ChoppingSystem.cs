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
        
        private GameObject _lowestSegment;
        
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
            _lowestSegment = _treeRoot.transform.GetChild(0).gameObject;
            _lowestSegment.transform.SetParent(null);
            _lowestSegment.GetComponentInChildren<Collider2D>().enabled = false;
            
            var throwStrategy =  _gameplayController.GetThrowStrategy();
            throwStrategy.Throw(_lowestSegment, _movementData.CurrentSide);
            
            Object.Destroy(_lowestSegment,2);
            
            _segmentChoppedSignal.Fire(1);
            _treeData.ShouldMoveTree = true;
            
            _gameplayController.SendActivationRequest<ChoppingSystem>(RequestMode.Deactivation);
        }

        private void ThrowSegments()
        {
            Rigidbody2D rb = _lowestSegment.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;
            
            rb.AddForce(Vector2.one  * 10f, ForceMode2D.Impulse);
            
            Object.Destroy(_lowestSegment,2);
        }

        private void ThrowSegments(bool usingDoTween)
        {
            _lowestSegment.Throw();
        }
    }
}
