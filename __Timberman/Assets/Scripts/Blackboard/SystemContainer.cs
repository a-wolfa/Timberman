using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Systems;
using Systems.Abstractions;
using Systems.Data;
using Systems.Data.Abstractions;
using UnityEngine;

namespace Blackboard
{
    public class SystemContainer
    {
        private readonly BaseSystem[] _orderedSystems;
        private readonly Dictionary<Type, BaseSystem> _systems;
        private List<BaseSystem> _activeSystems;

        private readonly List<BaseSystem> _systemsToActivate;
        private readonly List<BaseSystem> _systemsToDeactivate;

        public SystemContainer(BaseSystem[] systems)
        {
            _orderedSystems = systems;
            _systems = systems.ToDictionary(s => s.GetType(),  s => s);
            
            _activeSystems = new List<BaseSystem>();
            _systemsToActivate = new List<BaseSystem>();
            _systemsToDeactivate = new List<BaseSystem>();
        }

        public void InitActiveSystems()
        {
            RequestDeactivation<ChoppingSystem>();
            RequestDeactivation<TimerSystem>();
            RequestDeactivation<InputSystem>();
            DeactivatePendingSystems();
        }

        

        public void Update()
        {
            ActivatePendingSystems();

            foreach (var system in _activeSystems)
            {
                system.Update();
            }
            
            DeactivatePendingSystems();
        }
        
        private void ActivatePendingSystems()
        {
            if (_systemsToActivate.Count == 0)
                return;
            
            _activeSystems.AddRange(_systemsToActivate);
            _activeSystems = _activeSystems.OrderBy(s => Array.IndexOf(_orderedSystems, s)).ToList();
            
            _systemsToActivate.Clear();
        }

        private void DeactivatePendingSystems()
        {
            if (_systemsToDeactivate.Count == 0)
                return;
            
            _activeSystems.RemoveAll(system => _systemsToDeactivate.Contains(system));
            
            _systemsToDeactivate.Clear();
        }

        public void RequestActivation<TSystem>()  where TSystem : BaseSystem
        {
            var system = _systems[typeof(TSystem)];
            if (_activeSystems.Contains(system) || _systemsToActivate.Contains(system)) return;

            _systemsToActivate.Add(system);
        }

        public void RequestDeactivation<TSystem>() where TSystem : BaseSystem
        {
            var system = _systems[typeof(TSystem)];
            if (!_activeSystems.Contains(system) || _systemsToDeactivate.Contains(system)) return;
            
            if (system == null)
                return;
            
            _systemsToDeactivate.Add(system);
        }
    }
}