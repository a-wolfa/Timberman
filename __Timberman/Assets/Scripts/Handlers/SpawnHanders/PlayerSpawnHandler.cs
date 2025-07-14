using Factories.Player;
using Zenject;

namespace Handlers.SpawnHanders
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