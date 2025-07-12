using System;
using Components;
using Definitions;
using UnityEngine;

namespace Factories.FactoryManagers
{
    public class TreeSegmentManagerFactory
    {
        private readonly LeftBranchSegmentFactory _leftBranchFactory;
        private readonly RightBranchSegmentFactory _rightBranchFactory;
        private readonly NormalSegmentFactory _normalSegmentFactory;

        public TreeSegmentManagerFactory(
            LeftBranchSegmentFactory leftBranchFactory,
            RightBranchSegmentFactory rightBranchFactory,
            NormalSegmentFactory normalSegmentFactory
            )
        {
            _leftBranchFactory = leftBranchFactory;
            _rightBranchFactory = rightBranchFactory;
            _normalSegmentFactory = normalSegmentFactory;
        }

        public TreeSegment Create(Side side, Vector3 position)
        {
            TreeSegment segment = side switch
            {
                Side.Left => _leftBranchFactory.Create(position),
                Side.Right => _rightBranchFactory.Create(position),
                Side.None => _normalSegmentFactory.Create(position),
                _ => throw new ArgumentOutOfRangeException()
            };
            
            return segment;
        }
    }
}