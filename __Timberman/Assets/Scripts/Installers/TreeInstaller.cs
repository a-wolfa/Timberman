using Components;
using Factories;
using Factories.Abstractions;
using Factories.FactoryManagers;
using Pools;
using Systems;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class TreeInstaller : MonoInstaller
    {
        [SerializeField] private GameObject leftPrefab;
        [SerializeField] private GameObject rightPrefab;
        [SerializeField] private GameObject nonePrefab;

        public override void InstallBindings()
        {
            AddPrefabs();
            
            AddPool();

            AddFactory();
        }
        
        public override void Start()
        {
            Container.Resolve<TreeManagementSystem>().InitTree();
        }

        private void AddPrefabs()
        {
            Container.BindInstance(leftPrefab).WithId("LeftPrefab");
            Container.BindInstance(rightPrefab).WithId("RightPrefab");
            Container.BindInstance(nonePrefab).WithId("NonePrefab");
        }

        private void AddPool()
        {
            Container.BindMemoryPool<TreeSegment, LeftBranchSegmentPool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(leftPrefab)
                .UnderTransformGroup("PooledSegments");

            Container.BindMemoryPool<TreeSegment, RightBranchSegmentPool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(rightPrefab)
                .UnderTransformGroup("PooledSegments");

            Container.BindMemoryPool<TreeSegment, NoBranchSegmentPool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(nonePrefab)
                .UnderTransformGroup("PooledSegments");
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
