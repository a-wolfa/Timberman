using System.Collections.Generic;
using Components;
using Definitions;
using DG.Tweening;
using Factories.FactoryManagers;
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

        private float _segmentHeight = 2.56f;
        private List<TreeSegment> _segments;
        
        public TreeManagementSystem(
            TreeData treeData, 
            [Inject(Id = "Root")]Transform treeOrigin,
            TreeSegmentManagerFactory treeSegmentManagerFactory
            )
        {
            _treeData = treeData;
            _treeOrigin = treeOrigin;
            _treeSegmentManagerFactory = treeSegmentManagerFactory;
        }

        public void InitTree(int count = 10)
        {
            _segments  = new List<TreeSegment>();
            Side previousSide = Side.Right;

            for (int i = 0; i < count; i++)
            {
                Side side;
                

                if (previousSide != Side.None)
                {
                    // Force a normal (no branch) after a branch
                    side = Side.None;
                }
                else
                {
                    // Randomly choose between None, Left, Right
                    side = GetRandomBranchSide();
                }
                
                Debug.Log(side.ToString());

                Vector3 position = _treeOrigin.position + Vector3.up * i * _segmentHeight;
                
                TreeSegment segment = _treeSegmentManagerFactory.Create(side, position);
                segment.transform.SetParent(_treeOrigin);
                
                _segments.Add(segment);

                previousSide = side;
            }
            
        }

        public override void Update()
        {
            if (!_treeData.ShouldMoveTree)
                return;
            MoveTreeSegmentsDown();
        }

        private void MoveTreeSegmentsDown()
        {
            _treeOrigin.DOMoveY(_treeOrigin.position.y - _segmentHeight, .1f);
        }

        private Side GetRandomBranchSide()
        {
            var randomNumber = Random.Range(-1, 2);
            return (Side)randomNumber;
        }

    }
}
