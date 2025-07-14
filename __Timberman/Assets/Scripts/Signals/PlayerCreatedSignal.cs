using UnityEngine;
using Zenject;

namespace Signals
{
    public class PlayerCreatedSignal
    {
        public GameObject Player { get; set; }

        public PlayerCreatedSignal(GameObject player)
        {
            Player = player;
        }
    }
}