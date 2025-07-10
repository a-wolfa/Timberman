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
        private readonly SegmentChoppedSignal _segmentChoppedSignal;
        
        [Inject]
        public ScorePresenter(ScoreService scoreService, 
                             ScoreView scoreView, 
                             SegmentChoppedSignal segmentChoppedSignal)
        {
            _scoreService = scoreService;
            _scoreView = scoreView;
            _segmentChoppedSignal = segmentChoppedSignal;
        }
        
        public void Initialize()
        {
            _segmentChoppedSignal.Subscribe(OnSegmentChopped);
            UpdateScoreDisplay();
        }
        
        public void Dispose()
        {
            _segmentChoppedSignal?.Unsubscribe(OnSegmentChopped);
        }
        
        private void OnSegmentChopped(int points)
        {
            _scoreService.AddPoints(points);
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
