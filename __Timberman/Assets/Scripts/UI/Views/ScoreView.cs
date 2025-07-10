using UnityEngine;
using TMPro;
using Zenject;

namespace UI.Views
{
    public class ScoreView : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        
        [Inject]
        public void Construct([Inject(Id = "ScoreText")] TextMeshProUGUI scoreText)
        {
            _scoreText = scoreText;
        }
        
        public void UpdateScore(int score)
        {
            if (_scoreText != null)
            {
                _scoreText.text = $"{score}";
            }
        }
    }
}
