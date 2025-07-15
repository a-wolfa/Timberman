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
        private readonly BaseSystem[] _systems;
        private List<BaseSystem> _activeSystems;

        private List<BaseSystem> _systemsToActivate;
        private readonly List<BaseSystem> _systemsToDeactivate;

        public SystemContainer(BaseSystem[] systems)
        {
            _systems = systems;
            _activeSystems = systems.ToList();
            
            _systemsToActivate = new List<BaseSystem>();
            _systemsToDeactivate = new List<BaseSystem>();
            
            InitActiveSystems();
        }

        public void InitActiveSystems()
        {
            RequestToDeactivateSystem<ChoppingSystem>();
            RequestToDeactivateSystem<TimerSystem>();
            RequestToDeactivateSystem<InputSystem>();
            DeactivateSystems();
        }

        private void ActivateSystems()
        {
            _activeSystems.AddRange(_systemsToActivate);
            _systemsToActivate.Clear();
            _activeSystems = _activeSystems.OrderBy(system => _systems.IndexOf(system)).ToList();
        }

        private void DeactivateSystems()
        {
            _activeSystems.RemoveAll(system => _systemsToDeactivate.Contains(system));
            _systemsToDeactivate.Clear();
        }

        public void Update()
        {
            ActivateSystems();

            foreach (var system in _activeSystems)
            {
                system.Update();
                Debug.Log(system.GetType().Name);
            }
            
            DeactivateSystems();
        }

        public void RequestToActivateSystem<TSystem>()  where TSystem : BaseSystem
        {
            var systemToActivate = _systems.FirstOrDefault(system => system is TSystem);
            _systemsToActivate.Add(systemToActivate);
        }

        public void RequestToDeactivateSystem<TSystem>() where TSystem : BaseSystem
        {
            var systemToDeactivate = _activeSystems.FirstOrDefault(system => system is TSystem);
            
            if (systemToDeactivate == null)
                return;
            
            _systemsToDeactivate.Add(systemToDeactivate);
        }
    }
}