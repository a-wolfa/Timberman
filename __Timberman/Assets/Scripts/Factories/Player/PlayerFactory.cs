using Data;
using Signals;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Factories.Player
{
    public class PlayerFactory
    {
        private readonly DiContainer _container;
        private readonly SignalBus _signalBus;
        
        
        private ThemeData _themeData;
        
        public GameObject PlayerInstance { get; private set; }

        public PlayerFactory(DiContainer container, SignalBus signalBus)
        {
            _container = container;
            _signalBus = signalBus;
            
            _signalBus.Subscribe<ThemeSelectedSignal>(Create);
        }

        public void Create(ThemeSelectedSignal signal)
        {
            _themeData = signal.ThemeData;
            _themeData.Player.prefab.LoadAssetAsync().Completed += OnPrefabLoaded;
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
            
            _signalBus.Fire(new PlayerCreatedSignal(PlayerInstance));
        }
    }
}
