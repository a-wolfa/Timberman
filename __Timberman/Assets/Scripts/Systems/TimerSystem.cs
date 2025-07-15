using Signals;
using Systems.Abstractions;
using Systems.Data;
using UI.Views;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class TimerSystem : BaseSystem
    {
        private readonly TimerData _timerData;
        private readonly TimerView _timerView;
        private readonly SignalBus _signalBus;

        private float _currentTime;
        private float _maxTime = 8;

        public TimerSystem(
            TimerData timerData, 
            TimerView timerView, 
            SignalBus signalBus)
        {
            _timerData = timerData;
            _timerView = timerView;
            _signalBus = signalBus;
        }

        public void Init()
        {   
            _signalBus.Subscribe<ChoppedSignal>(ChargeTimer);
            _currentTime = _maxTime/2;
        }

        public override void Update()
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
                _currentTime = Mathf.Max(_currentTime, 0);

                _timerView.SetSlider(_currentTime);
                _timerView.SetFill(_currentTime / _maxTime);
            }
            else
            {
                Debug.Log("Timer Expired");
                _signalBus.Fire<TimerExpiredSignal>();
            }
        }

        private void ChargeTimer(ChoppedSignal choppedSignal)
        {
            _currentTime = Mathf.Min(_currentTime + .2f, _maxTime);
        }

    }
}
