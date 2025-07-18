using Controllers;
using GameStates;
using GameStates.Abstractions;
using Zenject;

namespace Installers
{
    public class GameStateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            AddStates();
        }

        private void AddStates()
        {
            Container.Bind<ReadySate>().AsTransient();
            Container.Bind<BaseGameSate>().To<ReadySate>().FromResolve();
            
            Container.Bind<ThemeSelectionSate>().AsTransient();
            Container.Bind<BaseGameSate>().To<ThemeSelectionSate>().FromResolve();

            Container.Bind<PlayingState>().AsTransient();
            Container.Bind<BaseGameSate>().To<PlayingState>().FromResolve();

            Container.Bind<DeathState>().AsTransient();
            Container.Bind<BaseGameSate>().To<DeathState>().FromResolve();
        }
    }
}
