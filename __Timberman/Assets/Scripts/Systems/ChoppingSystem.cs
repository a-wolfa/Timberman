using Components;
using Controllers;
using Definitions;
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
        private readonly SignalBus _signalBus;

        GameplayController _gameplayController;

        private TreeSegment _bottomSegment;

        private Rigidbody2D _rb2D;

        public ChoppingSystem(TreeData treeData,
            GameplayController gameplayController,
            SignalBus signalBus,
            [Inject(Id = "Root")] Transform treeRoot,
            MovementData movementData)
        {
            _treeData = treeData;
            _movementData = movementData;
            _gameplayController = gameplayController;
            _signalBus = signalBus;
            _treeRoot = treeRoot;
        }

        public override void Update()
        {
            _bottomSegment = _treeData.Segments[0];
            _bottomSegment.transform.SetParent(null);
            _treeData.Segments.RemoveAt(0);

            _gameplayController.playerSide = _movementData.CurrentSide;

            var throwStrategy = _gameplayController.GetThrowStrategy();
            throwStrategy.Throw(_bottomSegment, _movementData.CurrentSide);

            _signalBus.Fire(new SegmentChoppedSignal());
            _treeData.ShouldMoveTree = true;

            _gameplayController.SendActivationRequest<ChoppingSystem>(RequestMode.Deactivation);
        }
    }
}
