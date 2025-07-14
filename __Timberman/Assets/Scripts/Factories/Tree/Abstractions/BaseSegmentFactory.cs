using Components;
using UnityEngine;
using Zenject;

namespace Factories.Tree.Abstractions
{
    public abstract class BaseSegmentFactory<TPool> : IFactory<Vector3, TreeSegment>
        where TPool : IMemoryPool<Vector3, TreeSegment>
    {
        protected readonly DiContainer Container;

        protected BaseSegmentFactory(DiContainer container)
        {
            Container = container;
        }

        public TreeSegment Create(Vector3 position)
        {
            return Container.Resolve<TPool>().Spawn(position);
        }
    }
}