using Blackboard;
using Data;
using Systems;
using Systems.Abstractions;
using Systems.Data;
using Systems.Data.Abstractions;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "CoreSystemsInstaller", menuName = "Installers/CoreSystemsInstaller")]
    public class CoreSystemInstaller : ScriptableObjectInstaller<CoreSystemInstaller>
    {
        [SerializeField] private GameBalanceConfig gameBalanceConfig;
        
        public override void InstallBindings()
        {
            AddData();
            AddSystems();
            AddContainers();
            AddConfigs();
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
            
            Container.BindInterfacesAndSelfTo<TimerSystem>().AsSingle();
            Container.Bind<BaseSystem>().To<TimerSystem>().FromResolve();
        }

        private void AddContainers()
        {
            Container.Bind<DataContainer>().AsSingle();
            Container.Bind<SystemContainer>().AsSingle();
        }

        private void AddConfigs()
        {
            Container.Bind<GameBalanceConfig>()
                .FromInstance(gameBalanceConfig)
                .AsSingle();
        }

        
    }
}