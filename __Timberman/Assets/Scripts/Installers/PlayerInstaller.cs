using Handlers.Player;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerFactory>().AsSingle();
            //Container.BindInterfacesTo<PlayerSpawnHandler>().AsSingle();
        }
    }
    
}