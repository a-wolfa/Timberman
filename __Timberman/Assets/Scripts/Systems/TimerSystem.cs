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
        [Inject] private readonly TimerExpiredSignal _timerExpiredSignal;

        private readonly TimerData _timerData;
        private readonly TimerView _timerView;

        private float _currentTime;
        private float _maxTime = 5;

        public TimerSystem(TimerData timerData, TimerView timerView)
        {
            _timerData = timerData;
            _timerView = timerView;

            _timerData.StartTimer(5);
            
            Init();
        }

        private void Init()
        {
            _currentTime = _maxTime;
        }

        public override void Update()
            {
                Debug.Log(_currentTime);
                if (_currentTime > 0)
                {
                    _currentTime -= Time.deltaTime;
                    _currentTime = Mathf.Max(_currentTime, 0);

                    _timerView.SetSlider(_currentTime);
                    _timerView.SetFill(_currentTime / _maxTime);
                }
                else
                {
                    
                }
            }

        }
}
