using Controllers;
using Zenject;

namespace Systems.Abstractions
{
    public abstract class BaseSystem
    {
        [Inject] public GameplayController GameplayController;
        public abstract void Update();
    }
}
