using System;
using Signals;
using UnityEngine;
using TMPro;
using Zenject;

namespace UI.Views
{
    public class ScoreView : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        private SignalBus _signalBus;
        
        [Inject]
        public void Construct([Inject(Id = "ScoreText")] TextMeshProUGUI scoreText, SignalBus signalBus)
        {
            _scoreText = scoreText;
            _signalBus = signalBus;
        }
        
        public void UpdateScore(int score)
        {
            if (_scoreText)
            {
                _scoreText.text = $"{score}";
            }
        }

        
    }
}
