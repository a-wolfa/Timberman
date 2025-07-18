using System;
using Controllers;
using Signals;
using UnityEngine;
using Zenject;

namespace Components
{
    public class Player : MonoBehaviour
    {
        private GameObject _tombstone;
        private SpriteRenderer _spriteRenderer;

        [Inject] private SignalBus _signalBus;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            InitComponents();
            InitRefs();
        }

        private void InitComponents()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void InitRefs()
        {
            _tombstone = transform.GetChild(1).gameObject;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
            _signalBus.Subscribe<TimerExpiredSignal>(OnPlayerDied);
        }

        private void OnPlayerDied()
        {
            _spriteRenderer.enabled = false;
            _tombstone.SetActive(true);
        }
    }
}