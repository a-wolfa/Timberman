using Blackboard;
using Controllers;
using Definitions;
using Handlers;
using Handlers.Environment;
using Resolvers;
using Services;
using Signals;
using Strategies.InputStrategy;
using Strategies.InputStrategy.Abstractions;
using Strategies.ThrowStrategies;
using Strategies.ThrowStrategies.Abstractions;
using Systems;
using Systems.Abstractions;
using Systems.Data;
using Systems.Data.Abstractions;
using TMPro;
using UI.Views;
using UI.Presenters;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using InputSystem = Systems.InputSystem;

namespace Installers
{
    public class BlackboardInstaller : MonoInstaller
    {
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] private GameObject treeSegmentPrefab;
        [SerializeField] private Transform treeParent;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip chopSoundClip;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        public override void InstallBindings()
        {
            AddSignals();
            AddInput();
            AddAudio();
            AddUI();
            AddServices();
            AddData();
            AddSystems();
            AddInputAsset();
            AddContainers();
            AddTree();
            AddController();
            AddThrow();
            AddEnvironment();
        }

        public override void Start()
        {
            Container.Resolve<AudioService>().Init();
            Container.Resolve<InputSystem>().Init();
            Container.Resolve<TimerSystem>().Init();
            Container.Resolve<ScorePresenter>().Init();
            Container.Resolve<MovementSystem>().Init();
            Container.Resolve<AnimationSystem>().Init();
        }

        private void AddEnvironment()
        {
            Container.Bind<EnvironmentFactory>().AsSingle();
        }

        private void AddSystems()
        {
            Container.Bind<InputSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<InputSystem>().FromResolve();
            
            Container.Bind<AnimationSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<AnimationSystem>().FromResolve();
            
            Container.Bind<MovementSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<MovementSystem>().FromResolve();
            
            Container.Bind<ChoppingSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<ChoppingSystem>().FromResolve();
            
            Container.Bind<TreeManagementSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<TreeManagementSystem>().FromResolve();
            
            Container.Bind<TimerSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<TimerSystem>().FromResolve();
        }

        private void AddData()
        {
            Container.Bind<InputData>().AsSingle();
            Container.Bind<BaseData>().To<InputData>().FromResolve();
            
            Container.Bind<MovementData>().AsSingle();
            Container.Bind<BaseData>().To<MovementData>().FromResolve();
            
            Container.Bind<TreeData>().AsSingle();
            Container.Bind<BaseData>().To<TreeData>().FromResolve();
            
            Container.Bind<TimerData>().AsSingle();
            Container.Bind<BaseData>().To<TimerData>().FromResolve();
            
        }

        private void AddContainers()
        {
            Container.Bind<DataContainer>().AsSingle();
            Container.Bind<SystemContainer>().AsSingle();
        }

        private void AddInputAsset()
        {
            Container.Bind<InputActionAsset>().FromInstance(inputActionAsset).NonLazy();
        }

        private void AddTree()
        {
            Container.Bind<Transform>()
                .WithId("Root")
                .FromInstance(treeParent)
                .AsSingle();
        }

        private void AddController()
        {
            Container.Bind<GameplayController>().FromComponentInHierarchy().AsSingle();
        }
        
        private void AddSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerCreatedSignal>();
            Container.DeclareSignal<InputPerformedSignal>();
            Container.DeclareSignal<ChoppedSignal>();
            Container.DeclareSignal<TimerExpiredSignal>();
            Container.DeclareSignal<ThemeSelectedSignal>();
        }

        private void AddInput()
        {
#if UNITY_EDITOR
            Container.Bind<IInputStrategy>()
                .To<KeyboardInputStrategy>()
                .AsSingle();
#elif UNITY_ANDROID
            Container.Bind<IInputStrategy>()
                .To<TouchInputStrategy>()
                .AsSingle();
#else
            Container.Bind<IInputStrategy>()
                .To<KeyboardInputStrategy>()
                .AsSingle();
#endif
        }

        
        private void AddAudio()
        {
            Container.Bind<AudioSource>()
                .WithId("ChopAudioSource")
                .FromInstance(audioSource)
                .AsSingle();
                
            Container.Bind<AudioClip>()
                .WithId("ChopSound")
                .FromInstance(chopSoundClip)
                .AsSingle();
        }
        
        private void AddUI()
        {
            Container.Bind<TextMeshProUGUI>()
                .WithId("ScoreText")
                .FromInstance(scoreText)
                .AsSingle();
            
            Container.Bind<TimerView>().FromComponentInHierarchy().AsSingle();
        }
        
        private void AddServices()
        {
            // MVP Pattern for Score
            Container.Bind<ScoreService>().AsSingle();
            Container.Bind<ScoreView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<ScorePresenter>().AsSingle();
            
            // Other services
            Container.BindInterfacesAndSelfTo<AudioService>().AsSingle();
        }
        
        public void AddThrow()
        {
            Container.Bind<IThrow>().WithId(ThrowMode.DoThrow).To<DoThrow>().AsSingle();
            Container.Bind<IThrow>().WithId(ThrowMode.RbThrow).To<RbThrow>().AsSingle();
            Container.Bind<ThrowResolver>().AsSingle();
        }
    }
}
