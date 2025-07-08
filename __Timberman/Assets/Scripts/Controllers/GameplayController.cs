using System;
using Blackboard;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class GameplayController : MonoBehaviour
    {
        [Inject] private readonly SystemContainer _systemContainer;
        [Inject] private readonly DataContainer _dataContainer;

        private void Update()
        {
            _systemContainer.Update();
            _dataContainer.Update();
        }
    }
}