using Blackboard;
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
        public override void InstallBindings()
        {
            AddData();
            AddSystems();
            
            
            AddContainers();
            AddInputAsset();
        }

        private void AddSystems()
        {
            Container.Bind<InputSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<InputSystem>().FromResolve();
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
        
    }
}