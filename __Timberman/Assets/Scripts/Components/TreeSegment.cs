using System.Collections;
using System.Collections.Generic;
using Definitions;
using Pools;
using UnityEngine;
using Zenject;

namespace Components
{
    public class TreeSegment : MonoBehaviour, IPoolable<Vector3, IMemoryPool>
    {
        private IMemoryPool _pool;
        
        [SerializeField] private Side branchSide;
        public Side BranchSide { get => branchSide; set => branchSide = value; }
        
        public void SetPool(IMemoryPool pool)
        {
            _pool = pool;
        }
        
        public void Initialize(Side side)
        {
            branchSide = side;
        }

        public void OnDespawned()
        {
            gameObject.SetActive(false);
            _pool = null;
        }

        public void OnSpawned(Vector3 p1, IMemoryPool p2)
        {
            _pool = p2;
            transform.position = p1;
            gameObject.SetActive(true);
        }
        

        public void Despawn() => _pool.Despawn(this);

        public void DespawnWithDelay(float delay = .2f)
        {
            StartCoroutine(DespawnCoroutine(delay));
        }

        private IEnumerator DespawnCoroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            Despawn();
        }

        
    }
}
