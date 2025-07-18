using System;
using Zenject;
using Services;
using Signals;
using UI.Views;

namespace UI.Presenters
{
    public class ScorePresenter : IInitializable, IDisposable
    {
        private readonly ScoreService _scoreService;
        private readonly ScoreView _scoreView;
        private readonly SignalBus _signalBus;
        
        public ScorePresenter(ScoreService scoreService, ScoreView scoreView, SignalBus segmentChoppedSignal)
        {
            _scoreService = scoreService;
            _scoreView = scoreView;
            _signalBus = segmentChoppedSignal;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<SegmentChoppedSignal>(OnSegmentChopped);
            _signalBus.Subscribe<ScoreChangedSignal>(OnScoreChanged);
            UpdateScoreDisplay();
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SegmentChoppedSignal>(OnSegmentChopped);
            _signalBus.Unsubscribe<ScoreChangedSignal>(OnScoreChanged);
        }
        
        private void OnSegmentChopped(SegmentChoppedSignal segmentChoppedSignal)
        {
            _scoreService.AddPoints(1);
        }

        private void OnScoreChanged(ScoreChangedSignal signal)
        {
            _scoreView.UpdateScore(signal.NewScore);
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
