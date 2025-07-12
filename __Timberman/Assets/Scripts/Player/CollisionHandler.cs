using System;
using Components;
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
        [SerializeField] private LayerMask branchLayer;
        
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
            if (((1 << other.gameObject.layer) & branchLayer) == 0)
                return;

            var branchSide = other.transform.GetComponentInParent<TreeSegment>().BranchSide;
            if (_gameplayController.playerSide == branchSide)
                Die();
        }

        public void Die()
        {
            _spriteRenderer.enabled = false;
            _tombstone.SetActive(true);
            
            _gameplayController.SendActivationRequest<InputSystem>(RequestMode.Deactivation);
            _gameplayController.SendActivationRequest<TimerSystem>(RequestMode.Deactivation);
            
        }
    }
}
