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

        public override void Start()
        {
            Container.Resolve<ReadyState>().Init();
        }

        private void AddControllers()
        {
            Container.Bind<GameStateController>().FromComponentInHierarchy().AsSingle();
        }

        private void AddStates()
        {
            Container.Bind<ReadyState>().AsSingle();
            Container.Bind<IGameState>().To<ReadyState>().FromResolve();
        }
    }
}
