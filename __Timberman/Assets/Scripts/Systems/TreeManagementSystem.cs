using System.Collections.Generic;
using Components;
using DG.Tweening;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class TreeManagementSystem : BaseSystem
    {
        private readonly TreeData _treeData;
        private readonly Transform _treeOrigin;

        private float _yValueToMove = 2.56f;
        
        public TreeManagementSystem(TreeData treeData, [Inject(Id = "Root")]Transform treeOrigin)
        {
            _treeData = treeData;
            _treeOrigin = treeOrigin;
        }

        public override void Update()
        {
            if (!_treeData.ShouldMoveTree)
                return;
            MoveTreeSegmentsDown();
        }

        private void MoveTreeSegmentsDown()
        {
            _treeOrigin.DOMoveY(_treeOrigin.position.y - _yValueToMove, .1f);
        }

    }
}
