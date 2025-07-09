using Systems;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Animator playerAnimator;
        public override void InstallBindings()
        {
            AddAnimator();
        }
        
        private void AddAnimator()
        {
            Container.Bind<Animator>()
                .FromInstance(playerAnimator)
                .AsSingle()
                .WhenInjectedInto<AnimationSystem>();
        }
    }
}