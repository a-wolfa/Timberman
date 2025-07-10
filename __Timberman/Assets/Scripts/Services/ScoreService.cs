using System;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ScoreService
    {
        private int _score = 0;
        
        public void AddPoints(int points)
        {
            _score += points;
        }
        
        public int GetCurrentScore()
        {
            return _score;
        }
        
        public void ResetScore()
        {
            _score = 0;
        }
    }
}
