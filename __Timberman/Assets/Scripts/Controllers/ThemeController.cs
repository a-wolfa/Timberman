using System;
using Data;
using Definitions;
using Signals;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class ThemeController : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        
        [SerializeField] private ThemeData themeData;

        private void OnEnable()
        {
            _signalBus.Subscribe<ThemeSelectedSignal>(OnThemeSelected);
        }

        private void OnThemeSelected(ThemeSelectedSignal signal)
        {
            themeData = signal.ThemeData;
        }
    }
}
