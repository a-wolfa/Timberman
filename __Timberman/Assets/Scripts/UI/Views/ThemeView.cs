using System;
using Data;
using Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Views
{
    public class ThemeView : MonoBehaviour
    {
        [SerializeField] private ThemeData themeData;
        
        [Inject] private SignalBus _signalBus;

        private Button _button;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            InitComponents();
            InitCommands();
        }

        private void InitComponents()
        {
            _button = GetComponent<Button>();
        }

        private void InitCommands()
        {
            _button.onClick.AddListener(() =>
            {
                _signalBus.Fire(new ThemeSelectedSignal(themeData));
            });
        }
    }
}
