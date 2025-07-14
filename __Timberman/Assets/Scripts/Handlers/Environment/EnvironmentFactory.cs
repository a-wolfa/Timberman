using Data;
using Signals;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Handlers.Environment
{
    public class EnvironmentFactory
    {
        private readonly DiContainer _container;
        private readonly SignalBus _signalBus;
        
        private ThemeData _theme;

        private GameObject PlayerInstance { get; set; }

        public EnvironmentFactory(DiContainer container, SignalBus signalBus)
        {
            _container = container;
            _signalBus = signalBus;
            
            _signalBus.Subscribe<ThemeSelectedSignal>(Create);
        }

        private void Create(ThemeSelectedSignal signal)
        {
            _theme = signal.ThemeData;
            _theme.Forest.prefab.LoadAssetAsync().Completed += OnPrefabLoaded;
        }

        private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle)
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError(handle.Status.ToString());
                return;
            }
            
            GameObject prefab = handle.Result;
            PlayerInstance = _container.InstantiatePrefab(prefab);
        }
    }
}