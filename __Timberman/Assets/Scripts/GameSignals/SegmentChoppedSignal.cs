using System;
using UnityEngine;

namespace GameSignals
{
    public class SegmentChoppedSignal
    {
        public event Action<int> OnSegmentChopped;
        
        public void Fire(int pointsAwarded = 10)
        {
            Debug.Log($"SegmentChoppedSignal: Firing with {pointsAwarded} points");
            OnSegmentChopped?.Invoke(pointsAwarded);
        }
        
        public void Subscribe(Action<int> callback)
        {
            OnSegmentChopped += callback;
        }
        
        public void Unsubscribe(Action<int> callback)
        {
            OnSegmentChopped -= callback;
        }
    }
}
