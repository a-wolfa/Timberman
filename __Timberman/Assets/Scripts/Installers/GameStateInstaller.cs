using Controllers;
using GameStates;
using GameStates.Abstraction;
using Zenject;

namespace Installers
{
    public class GameStateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            AddStates();
            AddControllers();
        }

        private void AddControllers()
        {
            Container.Bind<GameStateController>().FromComponentInHierarchy().AsSingle();
        }

        private void AddStates()
        {
            Container.Bind<ReadySate>().AsTransient();
            Container.Bind<BaseGameSate>().To<ReadySate>().FromResolve();
            
            Container.Bind<ThemeSelectionSate>().AsTransient();
            Container.Bind<BaseGameSate>().To<ThemeSelectionSate>().FromResolve();

            Container.Bind<PlayingState>().AsTransient();
            Container.Bind<BaseGameSate>().To<PlayingState>().FromResolve();
        }
    }
}
