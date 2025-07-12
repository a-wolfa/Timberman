using Factories.Abstractions;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class NormalSegmentFactory : BaseSegmentFactory
    {
        public NormalSegmentFactory(DiContainer container, [Inject(Id = "NonePrefab")] GameObject prefab)
            : base(container, prefab) { }
    }
}