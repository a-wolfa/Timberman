using Components;
using Pools;
using UnityEngine;
using Zenject;

namespace Factories.Abstractions
{
    public abstract class BaseSegmentFactory<TPool> : IFactory<Vector3, TreeSegment>
        where TPool : IMemoryPool<Vector3, TreeSegment>
    {
        protected readonly TPool Pool;

        protected BaseSegmentFactory(TPool pool)
        {
            Pool = pool;
        }

        public TreeSegment Create(Vector3 position)
        {
            return Pool.Spawn(position);
        }
    }
}