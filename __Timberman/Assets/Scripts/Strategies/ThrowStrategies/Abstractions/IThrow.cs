using Components;
using Definitions;
using UnityEngine;

namespace Strategies.ThrowStrategies.Abstractions
{
    public interface IThrow
    {
        void Throw(TreeSegment segment, Side side);
    }
}
