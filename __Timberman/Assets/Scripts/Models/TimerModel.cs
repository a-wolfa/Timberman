namespace Models
{
    public class TimerModel
    {
        public float CurrentTime { get; private set; }
        public float InitialTime { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsPaused { get; private set; }
        
        public void StartTimer(float duration)
        {
            InitialTime = duration;
            CurrentTime = duration;
            IsActive = true;
            IsPaused = false;
        }
        
        public void PauseTimer()
        {
            IsPaused = true;
        }
        
        public void ResumeTimer()
        {
            IsPaused = false;
        }
        
        public void StopTimer()
        {
            IsActive = false;
            IsPaused = false;
        }
        
        public void ResetTimer()
        {
            CurrentTime = InitialTime;
            IsActive = false;
            IsPaused = false;
        }
        
        public void UpdateTime(float deltaTime)
        {
            if (!IsActive || IsPaused)
                return;
                
            CurrentTime -= deltaTime;
            
            if (CurrentTime <= 0f)
            {
                CurrentTime = 0f;
                IsActive = false;
            }
        }
        
        public float GetProgress()
        {
            if (InitialTime <= 0f) return 0f;
            return CurrentTime / InitialTime;
        }
        
        public float GetProgressInverse()
        {
            return 1f - GetProgress();
        }
        
        public bool HasExpired()
        {
            return CurrentTime <= 0f && !IsActive;
        }
        
        public bool IsRunning()
        {
            return IsActive && !IsPaused;
        }
    }
}
