using Blackboard;
using Controllers;
using Systems;
using Systems.Abstractions;
using Systems.Data;
using Systems.Data.Abstractions;
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
        public override void InstallBindings()
        {
            AddData();
            AddSystems();
            
            AddInputAsset();
            AddContainers();
            
            AddTree();
            AddController();
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
            
            Container.Bind<TreeSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<TreeSystem>().FromResolve();
            // Add other systems here
        }

        private void AddData()
        {
            Container.Bind<InputData>().AsSingle();
            Container.Bind<BaseData>().To<InputData>().FromResolve();
            
            Container.Bind<TreeData>().AsSingle();
            Container.Bind<BaseData>().To<TreeData>().FromResolve();
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
    }
}