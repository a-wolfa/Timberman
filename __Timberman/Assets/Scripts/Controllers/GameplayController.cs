using System;
using Blackboard;
using Definitions;
using Systems.Abstractions;
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

        public void SendActivationRequest<TSystem>(RequestMode request)  where TSystem : BaseSystem
        {
            if (request is RequestMode.Activation) 
                _systemContainer.RequestToActivateSystem<TSystem>();
            else if (request is RequestMode.Deactivation)
                _systemContainer.RequestToDeactivateSystem<TSystem>();
        }

        public void Die()
        {
            
        }
    }
}