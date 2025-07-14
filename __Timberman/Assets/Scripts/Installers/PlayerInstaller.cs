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
            AddPlayer();
            AddAnimator();
        }


        private void AddPlayer()
        {
            Container.Bind<GameObject>().FromInstance(playerPrefab).NonLazy();
        }
        
        private void AddAnimator()
        {
            var playerAnimator = playerPrefab.GetComponentInChildren<Animator>();
            Container.Bind<Animator>()
                .FromInstance(playerAnimator)
                .AsSingle()
                .WhenInjectedInto<AnimationSystem>();
        }
    }
}
