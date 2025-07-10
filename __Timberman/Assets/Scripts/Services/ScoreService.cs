using System;
using UnityEngine;
using Zenject;
using GameSignals;

namespace Services
{
    public class ScoreService : IInitializable, IDisposable
    {
        private int _score = 0;
        private SegmentChoppedSignal _segmentChoppedSignal;

        [Inject]
        public void Construct(SegmentChoppedSignal segmentChoppedSignal)
        {
            _segmentChoppedSignal = segmentChoppedSignal;
        }

        public void Initialize()
        {
            Debug.Log("ScoreService: Initialized - Subscribing to SegmentChoppedSignal");
            _segmentChoppedSignal.Subscribe(OnSegmentChopped);
        }

        public void Dispose()
        {
            Debug.Log("ScoreService: Disposing - Unsubscribing from SegmentChoppedSignal");
            _segmentChoppedSignal?.Unsubscribe(OnSegmentChopped);
        }

        private void OnSegmentChopped(int points)
        {
            _score += points;
            Debug.Log($"ScoreService: Current Score = {_score} (+{points} points)");
        }
        
        public int GetCurrentScore()
        {
            return _score;
        }
        
        public void ResetScore()
        {
            _score = 0;
            Debug.Log("ScoreService: Score reset to 0");
        }
    }
}
