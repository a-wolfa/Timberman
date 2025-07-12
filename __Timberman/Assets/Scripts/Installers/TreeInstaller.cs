using Factories;
using Factories.Abstractions;
using Factories.FactoryManagers;
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
            Container.BindInstance(leftPrefab).WithId("LeftPrefab");
            Container.BindInstance(rightPrefab).WithId("RightPrefab");
            Container.BindInstance(nonePrefab).WithId("NonePrefab");

            Container.Bind<LeftBranchSegmentFactory>().AsSingle();
            Container.Bind<RightBranchSegmentFactory>().AsSingle();
            Container.Bind<NormalSegmentFactory>().AsSingle();

            Container.Bind<TreeSegmentManagerFactory>().AsSingle();
        }

        public override void Start()
        {
            Container.Resolve<TreeManagementSystem>().InitTree();
        }
    }
}
