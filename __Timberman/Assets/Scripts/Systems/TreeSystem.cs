using System.Collections.Generic;
using Components;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class TreeSystem : BaseSystem
    {
        private readonly TreeData _treeData;
        private readonly Transform _treeOrigin;
        
        private float _lowestSegmentY;
        private float _highestSegmentY;
        
        public TreeSystem(TreeData treeData, [Inject(Id = "Root")]Transform treeOrigin)
        {
            _treeData = treeData;
            _treeOrigin = treeOrigin;
        }

        public override void Update()
        {
            if (_treeData.ShouldMoveTree)
                MoveTreeSegmentsDown();
        }

        private void MoveTreeSegmentsDown()
        {
            Debug.Log("Move Tree Segments Down");
        }

    }
}
