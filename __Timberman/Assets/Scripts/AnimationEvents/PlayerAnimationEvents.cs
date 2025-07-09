using System;
using Systems.Data;
using UnityEngine;
using Zenject;

namespace AnimationEvents
{
    public class PlayerAnimationEvents : MonoBehaviour
    {
        [SerializeField] private GameObject treeRoot;
        
        [Inject] private readonly TreeData _treeData;
        
        private Rigidbody _rb;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            _rb =  treeRoot.GetComponentInChildren<Rigidbody>();
        }

        public void Chop()
        {
            _rb.useGravity = true;
            
            var throwDir = treeRoot.transform.position.x > 0? 1f : -1f;
            _rb.AddForce((Vector3.left + Vector3.down) * 15 * throwDir, ForceMode.Impulse);
            
            _treeData.ShouldMoveTree = true;
        }
    }
}
