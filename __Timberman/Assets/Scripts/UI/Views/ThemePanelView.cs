using System;
using Signals;
using UnityEngine;
using Zenject;

namespace UI.Views
{
    public class ThemePanelView : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;

        private void OnEnable()
        {
            _signalBus.Subscribe<ThemeSelectedSignal>(OnThemeSelectedSignal);
        }

        private void OnThemeSelectedSignal()
        {
            gameObject.SetActive(false);
        }
    }
}