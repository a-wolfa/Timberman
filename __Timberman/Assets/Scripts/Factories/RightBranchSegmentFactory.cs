using Factories.Abstractions;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class RightBranchSegmentFactory : BaseSegmentFactory
    {
        public RightBranchSegmentFactory(DiContainer container, [Inject(Id = "RightPrefab")] GameObject prefab)
            : base(container, prefab) { }
    }
}