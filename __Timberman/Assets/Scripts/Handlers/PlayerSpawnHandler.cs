using Factories.Player;
using Zenject;

namespace Handlers
{
    public class PlayerSpawnHandler : IInitializable
    {
        private readonly PlayerFactory _factory;

        public PlayerSpawnHandler(PlayerFactory factory)
        {
            _factory = factory;
        }
        
        public void Initialize()
        {
            _factory.Create();
        }
    }
}