using System;
using Controllers;
using Definitions;
using Systems;
using UnityEngine;
using Zenject;

namespace Player
{
    public class CollisionHandler : MonoBehaviour
    {
        private GameObject _tombstone;
        private SpriteRenderer _spriteRenderer;
        
        [Inject] private GameplayController _gameplayController;
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            InitRefs();
            InitComponents();
        }

        private void InitComponents()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void InitRefs()
        {
            _tombstone = transform.GetChild(1).gameObject;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _spriteRenderer.enabled = false;
            _tombstone.SetActive(true);
            
            _gameplayController.SendActivationRequest<InputSystem>(RequestMode.Deactivation);
        }
    }
}
