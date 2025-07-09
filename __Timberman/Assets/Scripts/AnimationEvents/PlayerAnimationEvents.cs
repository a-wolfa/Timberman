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
        
        private GameObject _lowestSegment;

        public void Chop()
        {
            _lowestSegment = treeRoot.transform.GetChild(0).gameObject;
            _treeData.ShouldMoveTree = true;
            
            Destroy(_lowestSegment);
        }
    }
}
