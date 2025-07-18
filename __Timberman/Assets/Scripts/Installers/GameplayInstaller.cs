using Data;
using Definitions;
using Resolvers;
using Signals;
using Strategies.InputStrategy;
using Strategies.InputStrategy.Abstractions;
using Strategies.ThrowStrategies;
using Strategies.ThrowStrategies.Abstractions;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "GameplayInstaller", menuName = "Installers/GameplayInstaller")]
    public class GameplayInstaller : ScriptableObjectInstaller<GameplayInstaller>
    {
        [SerializeField] private ThrowConfig throwConfig;
        public override void InstallBindings()
        {
            AddSignals();
            AddInputStrategy();
            AddThrowStrategies();
            AddConfig();
        }

        private void AddSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerCreatedSignal>();
            Container.DeclareSignal<InputPerformedSignal>();
            Container.DeclareSignal<SegmentChoppedSignal>();
            Container.DeclareSignal<TimerExpiredSignal>();
            Container.DeclareSignal<ThemeSelectedSignal>();
            Container.DeclareSignal<PlayerDiedSignal>();
            Container.DeclareSignal<PoolTreeInitialized>();
        }

        private void AddInputStrategy()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
                Container.Bind<IInputStrategy>().To<KeyboardInputStrategy>().AsSingle();
#elif UNITY_ANDROID || UNITY_IOS
            Container.Bind<IInputStrategy>().To<TouchInputStrategy>().AsSingle();
#endif
            
        }

        private void AddThrowStrategies()
        {
            Container.Bind<IThrow>().WithId(ThrowMode.DoThrow).To<DoThrow>().AsSingle();
            Container.Bind<IThrow>().WithId(ThrowMode.RbThrow).To<RbThrow>().AsSingle();
            Container.Bind<ThrowResolver>().AsSingle();
        }

        private void AddConfig()
        {
            Container.Bind<ThrowConfig>().FromInstance(throwConfig).AsSingle();
        }
    }
}