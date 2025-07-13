using System;
using Zenject;
using Services;
using Signals;
using UI.Views;

namespace UI.Presenters
{
    public class ScorePresenter
    {
        private readonly ScoreService _scoreService;
        private readonly ScoreView _scoreView;
        private readonly SignalBus _signalBus;
        
        public ScorePresenter(ScoreService scoreService, 
                                ScoreView scoreView, 
                                SignalBus segmentChoppedSignal)
        {
            _scoreService = scoreService;
            _scoreView = scoreView;
            _signalBus = segmentChoppedSignal;
        }

        public void Init()
        {
            _signalBus.Subscribe<ChoppedSignal>(OnSegmentChopped);
            UpdateScoreDisplay();
        }
        
        private void OnSegmentChopped(ChoppedSignal choppedSignal)
        {
            _scoreService.AddPoints(1);
            UpdateScoreDisplay();
        }
        
        private void UpdateScoreDisplay()
        {
            var currentScore = _scoreService.GetCurrentScore();
            _scoreView.UpdateScore(currentScore);
        }
        
        public void ResetScore()
        {
            _scoreService.ResetScore();
            UpdateScoreDisplay();
        }
    }
}
