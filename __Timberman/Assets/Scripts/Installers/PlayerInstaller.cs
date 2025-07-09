using Systems;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Animator playerAnimator;
        public override void InstallBindings()
        {
            AddPlayer();
            AddAnimator();
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
    }
}