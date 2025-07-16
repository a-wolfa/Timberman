using UnityEngine;
using Zenject;

namespace Signals
{
    public readonly struct PlayerCreatedSignal
    {
        public GameObject Player { get; }

        public PlayerCreatedSignal(GameObject player)
        {
            Player = player;
        }
    }
}