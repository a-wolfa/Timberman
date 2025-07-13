using System.Buffers;
using Components;
using UnityEngine;
using Zenject;

namespace Pools
{
    public abstract class TreeSegmentPool : MonoMemoryPool<Vector3, TreeSegment>
    {
        protected override void Reinitialize(Vector3 position, TreeSegment segment)
        {
            segment.SetPool(this);
            segment.transform.position = position;
            segment.gameObject.SetActive(true);
        }
        
        protected override void OnDespawned(TreeSegment segment)
        {
            if (segment == null) return;
            
            segment.gameObject.SetActive(false); // Return to pool parent
            base.OnDespawned(segment);
        }
    }
}
