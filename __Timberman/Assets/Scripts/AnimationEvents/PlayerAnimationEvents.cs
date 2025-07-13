using System;
using Controllers;
using Definitions;
using Systems;
using Systems.Data;
using UnityEngine;
using Zenject;

namespace AnimationEvents
{
    public class PlayerAnimationEvents : MonoBehaviour
    {
        [SerializeField] private GameObject treeRoot;
        [Inject] private readonly TreeData _treeData;
        [Inject] GameplayController _gameplayController;

        public void Chop()
        {
            _gameplayController.SendActivationRequest<ChoppingSystem>(RequestMode.Activation);
        }
    }
}
