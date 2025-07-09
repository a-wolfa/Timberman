using Blackboard;
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
        [SerializeField] private GameObject playerPrefab;
        public override void InstallBindings()
        {
            AddData();
            AddSystems();
            
            AddInputAsset();
            AddContainers();
            AddPlayer();
        }

        private void AddSystems()
        {
            Container.Bind<InputSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<InputSystem>().FromResolve();
            
            Container.Bind<MovementSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<MovementSystem>().FromResolve();
            // Add other systems here
        }

        private void AddData()
        {
            Container.Bind<InputData>().AsSingle();
            Container.Bind<BaseData>().To<InputData>().FromResolve();
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

        private void AddPlayer()
        {
            Container.Bind<GameObject>().FromInstance(playerPrefab).NonLazy();
        }
        
    }
}