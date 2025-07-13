using Factories.Abstractions;
using Pools;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class RightBranchSegmentFactory : BaseSegmentFactory<RightBranchSegmentPool>
    {
        public RightBranchSegmentFactory(RightBranchSegmentPool pool)
            : base(pool) { }
    }
}