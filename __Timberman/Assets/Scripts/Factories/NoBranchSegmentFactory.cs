using Factories.Abstractions;
using Pools;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class NoBranchSegmentFactory : BaseSegmentFactory<NoBranchSegmentPool>
    {
        public NoBranchSegmentFactory(NoBranchSegmentPool pool)
            : base(pool) { }
    }
}