using Components;
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

        private TreeSegment _bottomSegment;

        private Rigidbody2D _rb2D;

        public ChoppingSystem(TreeData treeData,
            SignalBus signalBus,
            [Inject(Id = "Root")] Transform treeRoot,
            MovementData movementData)
        {
            _treeData = treeData;
            _movementData = movementData;
            _signalBus = signalBus;
            _treeRoot = treeRoot;
        }

        public override void Update()
        {
            _bottomSegment = _treeData.Segments[0];
            _bottomSegment.transform.SetParent(null);
            _treeData.Segments.RemoveAt(0);

            GameplayController.PlayerSide = _movementData.CurrentSide;

            var throwStrategy = GameplayController.GetThrowStrategy();
            throwStrategy.Throw(_bottomSegment, _movementData.CurrentSide);
            
            _treeData.ShouldMoveTree = true;

            GameplayController.SendActivationRequest<ChoppingSystem>(false);
        }
    }
}
