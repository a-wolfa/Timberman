using Systems;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;

        public override void InstallBindings()
        {
            var player = Container.InstantiatePrefab(playerPrefab);
            AddPlayer(player);
            AddAnimator(player);
        }

        private void AddPlayer(GameObject playerInstance)
        {
            Container.Bind<GameObject>().FromInstance(playerInstance).NonLazy();
        }

        private void AddAnimator(GameObject playerInstance)
        {
            var playerAnimator = playerInstance.GetComponentInChildren<Animator>();
            Container.Bind<Animator>()
                .FromInstance(playerAnimator)
                .AsSingle()
                .WhenInjectedInto<AnimationSystem>();
        }
    }
}
