using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameBalanceConfig", menuName = "Game/Game Balance Config")]
    public class GameBalanceConfig : ScriptableObject
    {
        [Header("Timer Settings")]
        public float maxTime = 8f;
        public float startingTime = 4f;
        public float chopBonusTime = 0.2f;

        [Header("Tree Settings")] 
        public float segmentHeight = 2.56f;
        public int initialSegmentCount = 10;
    }
}