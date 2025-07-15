using Components;
using Definitions;
using DG.Tweening;
using Strategies.ThrowStrategies.Abstractions;
using UnityEngine;

namespace Strategies.ThrowStrategies
{
    public class DoThrow : IThrow
    {
        public void Throw(TreeSegment segment, Side side)
        {
            var startPosition = segment.transform.position;
            segment.transform.DOMove(
                startPosition + new Vector3(-1 * (int)side, 0.5f, 0) * 20, 
                1.5f)
                    .OnComplete(() => segment.Despawn());
        }
    }
}