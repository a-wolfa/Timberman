using Components;
using Controllers;
using Definitions;
using Signals;
using Systems;
using UnityEngine;
using Zenject;

namespace Handlers
{
    public class CollisionHandler : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private GameplayController _gameplayController;
        
        [SerializeField] private LayerMask branchLayer;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (((1 << other.gameObject.layer) & branchLayer) == 0)
                return;

            var branchSide = other.transform.GetComponentInParent<TreeSegment>().BranchSide;
            if (_gameplayController.PlayerSide == branchSide)
                _signalBus.Fire<PlayerDiedSignal>();
        }
    }
}
