using Blackboard;
using Controllers;
using Definitions;
using Resolvers;
using Services;
using Signals;
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
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Animator playerAnimator;
        
        public override void InstallBindings()
        {
            AddSignals();
            AddAudio();
            AddUI();
            AddServices();
            
            AddData();
            AddSystems();
            
            AddInputAsset();
            AddContainers();
            
            AddTree();
            AddController();
            
            AddAnimator();
            AddPlayer();
            
            AddThrow();
        }

        public override void Start()
        {
            Container.Resolve<SystemContainer>().InitActiveSystems();
        }

        private void AddSystems()
        {
            Container.Bind<InputSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<InputSystem>().FromResolve();
            
            Container.Bind<MovementSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<MovementSystem>().FromResolve();
            
            Container.Bind<AnimationSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<AnimationSystem>().FromResolve();
            
            Container.Bind<ChoppingSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<ChoppingSystem>().FromResolve();
            
            Container.Bind<TreeManagementSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<TreeManagementSystem>().FromResolve();
            
            Container.Bind<TimerSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<TimerSystem>().FromResolve();
            // Add other systems here
        }

        private void AddData()
        {
            Container.Bind<InputData>().AsSingle();
            Container.Bind<BaseData>().To<InputData>().FromResolve();
            
            Container.Bind<TreeData>().AsSingle();
            Container.Bind<BaseData>().To<TreeData>().FromResolve();
            
            Container.Bind<TimerData>().AsSingle();
            Container.Bind<BaseData>().To<TimerData>().FromResolve();
            
            Container.Bind<MovementData>().AsSingle();
            Container.Bind<BaseData>().To<MovementData>().FromResolve();
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
            Container.Bind<SegmentChoppedSignal>().AsSingle();
            Container.Bind<TimerExpiredSignal>().AsSingle();
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
        
        private void AddAnimator()
        {
            Container.Bind<Animator>()
                .FromInstance(playerAnimator)
                .AsSingle()
                .WhenInjectedInto<AnimationSystem>();
        }
        
        private void AddPlayer()
        {
            Container.Bind<GameObject>().FromInstance(playerPrefab).NonLazy();
        }
        
        public void AddThrow()
        {
            Container.Bind<IThrow>().WithId(ThrowMode.DoThrow).To<DoThrow>().AsSingle();
            Container.Bind<IThrow>().WithId(ThrowMode.RbThrow).To<RbThrow>().AsSingle();
            Container.Bind<ThrowResolver>().AsSingle();
        }
        
    }
}
