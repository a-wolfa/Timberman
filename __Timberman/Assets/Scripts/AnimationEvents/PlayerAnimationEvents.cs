using Signals;
using UnityEngine;
using Zenject;

namespace AnimationEvents
{
    public class PlayerAnimationEvents : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;

        public void Chop()
        {
            _signalBus.Fire<SegmentChoppedSignal>();
        }
    }
}
