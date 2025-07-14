using System;
using Components;
using Definitions;
using UnityEngine;

namespace Factories.Tree.FactoryManagers
{
    public class TreeSegmentManagerFactory
    {
        private readonly LeftBranchSegmentFactory _leftBranchFactory;
        private readonly RightBranchSegmentFactory _rightBranchFactory;
        private readonly NoBranchSegmentFactory _noBranchSegmentFactory;

        public TreeSegmentManagerFactory(
            LeftBranchSegmentFactory leftBranchFactory,
            RightBranchSegmentFactory rightBranchFactory,
            NoBranchSegmentFactory noBranchSegmentFactory
            )
        {
            _leftBranchFactory = leftBranchFactory;
            _rightBranchFactory = rightBranchFactory;
            _noBranchSegmentFactory = noBranchSegmentFactory;
        }

        public TreeSegment Create(Side side, Vector3 position)
        {
            TreeSegment segment = side switch
            {
                Side.Left => _leftBranchFactory.Create(position),
                Side.Right => _rightBranchFactory.Create(position),
                Side.None => _noBranchSegmentFactory.Create(position),
                _ => throw new ArgumentOutOfRangeException()
            };
            
            segment.Initialize(side);
            return segment;
        }
    }
}