using Factories.Abstractions;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class LeftBranchSegmentFactory : BaseSegmentFactory
    {
        public LeftBranchSegmentFactory(DiContainer container, [Inject(Id = "LeftPrefab")] GameObject prefab)
            : base(container, prefab) { }
    }
}