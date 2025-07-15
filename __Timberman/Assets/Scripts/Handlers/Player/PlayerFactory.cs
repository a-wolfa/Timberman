using Data;
using Signals;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Handlers.Player
{
    public class PlayerFactory : IInitializable, IDisposable
    {
        private readonly DiContainer _container;
        private readonly SignalBus _signalBus;

        private ThemeData _theme;

        private GameObject PlayerInstance { get; set; }

        public PlayerFactory(DiContainer container, SignalBus signalBus)
        {
            _container = container;
            _signalBus = signalBus;
        }

        private async Task CreateAsync(ThemeSelectedSignal signal)
        {
            _theme = signal.ThemeData;

            var handle = _theme.Player.prefab.LoadAssetAsync<GameObject>();
            await handle.Task;

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"Failed to load player prefab: {handle.Status}");
                return;
            }

            GameObject prefab = handle.Result;
            PlayerInstance = _container.InstantiatePrefab(prefab);
            _signalBus.Fire(new PlayerCreatedSignal(PlayerInstance));
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ThemeSelectedSignal>(OnThemeSelected);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ThemeSelectedSignal>(OnThemeSelected);
        }

        private void OnThemeSelected(ThemeSelectedSignal signal)
        {
            _ = CreateAsync(signal);
        }
    }
}
