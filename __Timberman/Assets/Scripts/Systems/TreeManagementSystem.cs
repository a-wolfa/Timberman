using System.Collections.Generic;
using Components;
using Definitions;
using DG.Tweening;
using Factories.Tree;
using Factories.Tree.FactoryManagers;
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
        private readonly TreeSegmentManagerFactory _treeSegmentManagerFactory;

        private readonly float _segmentHeight = 2.56f;

        private Side _previousGeneratedSide = Side.Left;
        private Vector3 _previousGeneratedPosition;
        
        public TreeManagementSystem(
            TreeData treeData, 
            [Inject(Id = "Root")]Transform treeOrigin,
            TreeSegmentManagerFactory treeSegmentManagerFactory, 
            List<TreeSegment> segments,
            TreeFactory treeFactory)
        {
            _treeData = treeData;
            _treeOrigin = treeOrigin;
            _treeSegmentManagerFactory = treeSegmentManagerFactory;
        }

        public void InitTree(int count = 10)
        {
            _treeData.Segments  = new List<TreeSegment>();
            for (int i = 0; i < count; i++)
            {
                Vector3 position = _treeOrigin.position + Vector3.up * i * _segmentHeight;
                GenerateSegment(position);
            }
            
        }

        public void GenerateSegment(Vector3 position = default)
        {
            var side = _previousGeneratedSide != Side.None ? Side.None : GetRandomBranchSide();
            
            if (position == default)
            {
                position = _previousGeneratedPosition;
            }
            
            var segment = _treeSegmentManagerFactory.Create(side, position);
            segment.transform.SetParent(_treeOrigin);
                
            _treeData.Segments.Add(segment);
            
            _previousGeneratedSide = side;
            _previousGeneratedPosition = position;
        }

        public override void Update()
        {
            if (!_treeData.ShouldMoveTree)
                return;
            MoveTreeSegmentsDown();
        }

        private void MoveTreeSegmentsDown()
        {
            _treeOrigin.DOMoveY(_treeOrigin.position.y - _segmentHeight, .1f).onComplete += () =>
            {
                GenerateSegment();
            };
        }

        private Side GetRandomBranchSide()
        {
            var randomNumber = Random.Range(-1, 2);
            return (Side)randomNumber;
        }

    }
}
