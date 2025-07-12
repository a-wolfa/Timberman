using Components;
using UnityEngine;
using Zenject;

namespace Factories.Abstractions
{
    public abstract class BaseSegmentFactory : IFactory
    {
        protected readonly DiContainer Container;
        protected readonly GameObject Prefab;

        protected BaseSegmentFactory(DiContainer container, GameObject prefab)
        {
            Container = container;
            Prefab = prefab;
        }

        public TreeSegment Create(Vector3 position)
        {
            var instance = Container.InstantiatePrefabForComponent<TreeSegment>(Prefab);
            instance.transform.position = position;
            return instance;
        }
    }
}