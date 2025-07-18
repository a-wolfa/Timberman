using Signals;
using Zenject;

namespace Services
{
    public class ScoreService
    {
        private readonly SignalBus _signalBus;
        private int _score = 0;

        public ScoreService(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void AddPoints(int points)
        {
            _score += points;
            _signalBus.Fire(new ScoreChangedSignal(_score));
        }
        
        public int GetCurrentScore()
        {
            return _score;
        }
        
        public void ResetScore()
        {
            _score = 0;
            _signalBus.Fire(new ScoreChangedSignal(_score));
        }
    }
}
