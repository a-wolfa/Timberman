using Factories.Abstractions;
using Pools;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class LeftBranchSegmentFactory : BaseSegmentFactory<LeftBranchSegmentPool>
    {
        public LeftBranchSegmentFactory(LeftBranchSegmentPool pool)
            : base(pool) { }
    }
}