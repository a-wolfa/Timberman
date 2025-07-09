using Controllers;
using Definitions;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class ChoppingSystem : BaseSystem
    {
        [Inject (Id = "Root")] private Transform _treeRoot;
        [Inject] private readonly TreeData _treeData;
        [Inject] GameplayController _gameplayController;
        
        public override void Update()
        {
            var lowestSegment = _treeRoot.transform.GetChild(0).gameObject;
            _treeData.ShouldMoveTree = true;
            
            Object.Destroy(lowestSegment);
            
            _gameplayController.SendActivationRequest<ChoppingSystem>(RequestMode.Deactivation);
        }
    }
}