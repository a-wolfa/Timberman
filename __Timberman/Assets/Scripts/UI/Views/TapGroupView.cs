using System;
using Signals;
using UnityEngine;
using Zenject;

namespace UI.Views
{
    public class TapGroupView : MonoBehaviour
    {
        private SignalBus _signalBus;
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<InputPerformedSignal>(TurnOffVisuals);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<InputPerformedSignal>(TurnOffVisuals);
        }

        private void TurnOffVisuals()
        {
            gameObject.SetActive(false);
        }
    }
}