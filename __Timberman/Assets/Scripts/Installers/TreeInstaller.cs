using Components;
using Factories;
using Factories.Tree;
using Factories.Tree.FactoryManagers;
using Pools;
using Systems;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class TreeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TreeFactory>().AsSingle();
            
            AddFactory();
        }

        private void AddFactory()
        {
            Container.Bind<LeftBranchSegmentFactory>().AsSingle();
            Container.Bind<RightBranchSegmentFactory>().AsSingle();
            Container.Bind<NoBranchSegmentFactory>().AsSingle();

            Container.Bind<TreeSegmentManagerFactory>().AsSingle();
        }

        
    }
}
