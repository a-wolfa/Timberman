using System;
using Data;
using Definitions;
using Factories.Tree;
using Handlers.Environment;
using Handlers.Player;
using Signals;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class ThemeController : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        
        [Inject] private PlayerFactory _playerFactory;
        [Inject] private TreeFactory _treeFactory;
        [Inject] private EnvironmentFactory _environmentFactory;
        
    }
}
