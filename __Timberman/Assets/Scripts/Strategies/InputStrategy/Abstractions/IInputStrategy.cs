using UnityEngine.InputSystem;

namespace Strategies.InputStrategy.Abstractions
{
    public interface IInputStrategy
    {
        void Enable();
        void Disable();
        void Dispose();
    }
}
