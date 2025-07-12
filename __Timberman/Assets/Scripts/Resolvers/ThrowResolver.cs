using Definitions;
using Strategies.ThrowStrategies.Abstractions;
using UnityEngine;
using Zenject;

namespace Resolvers
{
    public class ThrowResolver
    {
        private readonly DiContainer _container;
        
        public ThrowResolver(DiContainer container)
        {
            _container = container;
        }

        public IThrow ResolveThrowType(ThrowMode mode)
        {
            var strategy = _container.ResolveId<IThrow>(mode);
            Debug.Log($"Resolved throw strategy: {strategy.GetType().Name} for mode: {mode}");
            return strategy;
        }
    }
}