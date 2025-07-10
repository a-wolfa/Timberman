using Signals;
using Systems.Abstractions;
using Systems.Data;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class TimerSystem : BaseSystem
    {
        [Inject] private readonly TimerExpiredSignal _timerExpiredSignal;
     
        private readonly TimerData _timerData;
        
        private bool _hasLoggedStart = false;

        public TimerSystem(TimerData timerData)
        {
            _timerData =  timerData;
            
            _timerData.StartTimer(5);
        }
        
        public override void Update()
        {
            if (_timerData.IsActive)
            {
                if (_timerData.CurrentTime > 0)
                {
                    _timerData.CurrentTime -= Time.deltaTime;
                    Debug.Log(_timerData.CurrentTime);
                }
                else
                {
                    // Fire Dead Signal
                }
            }
        }

    }
}
