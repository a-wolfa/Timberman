using Handlers.Environment;
using Handlers.Player;
using Zenject;

namespace Installers
{
    public class AddressableInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            AddPlayer();
            AddEnvironment();
        }

        private void AddPlayer()
        {
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
        }
        
        private void AddEnvironment()
        {
            Container.Bind<EnvironmentFactory>().AsSingle();
        }
    }
    
}