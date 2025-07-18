using System;
using Data;
using Signals;
using Systems.Abstractions;
using Systems.Data;
using UI.Views;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class TimerSystem : BaseSystem, IInitializable, IDisposable
    {
        private readonly TimerData _timerData;
        private readonly TimerView _timerView;
        private readonly SignalBus _signalBus;
        private readonly GameBalanceConfig _config;

        public TimerSystem(
            TimerData timerData, 
            TimerView timerView, 
            SignalBus signalBus,
            GameBalanceConfig config)
        {
            _timerData = timerData;
            _timerView = timerView;
            _signalBus = signalBus;
            _config = config;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<SegmentChoppedSignal>(ChargeTimer);
            _timerData.MaxTime = _config.maxTime;
            _timerData.CurrentTime = _config.startingTime;
            _timerView.InitializeUI(_config.maxTime, _config.startingTime);
        }
        
        public override void Update()
        {
            if (_timerData.CurrentTime > 0)
            {
                _timerData.CurrentTime -= Time.deltaTime;
                _timerData.CurrentTime = Mathf.Max(_timerData.CurrentTime, 0);

                _timerView.SetSlider(_timerData.CurrentTime);
            }
            else
            {
                _signalBus.Fire<TimerExpiredSignal>();
                GameplayController.SendActivationRequest<TimerSystem>(false);
            }
        }

        private void ChargeTimer(SegmentChoppedSignal segmentChoppedSignal)
        {
            _timerData.CurrentTime = Mathf.Min(_timerData.CurrentTime + _config.chopBonusTime, _timerData.MaxTime);
        }


        public void Dispose()
        {
            _signalBus.Unsubscribe<SegmentChoppedSignal>(ChargeTimer);
        }
    }
}
