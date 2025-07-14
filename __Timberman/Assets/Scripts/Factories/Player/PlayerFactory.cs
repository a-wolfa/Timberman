using Player;
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
        
        private const string PlayerAddress = "Prefabs/Player/Player";
        
        public GameObject PlayerInstance { get; private set; }

        public PlayerFactory(DiContainer container, SignalBus signalBus)
        {
            _container = container;
            _signalBus = signalBus;
        }

        public void Create()
        {
            Addressables.LoadAssetAsync<GameObject>(PlayerAddress).Completed += OnPrefabLoaded;
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
