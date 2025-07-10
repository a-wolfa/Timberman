using System;

namespace Signals
{
    public class TimerExpiredSignal
    {
        public event Action OnTimerExpired;
        
        public void Fire()
        {
            OnTimerExpired?.Invoke();
        }
        
        public void Subscribe(Action callback)
        {
            OnTimerExpired += callback;
        }
        
        public void Unsubscribe(Action callback)
        {
            OnTimerExpired -= callback;
        }
    }
}
