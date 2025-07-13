using Systems.Data.Abstractions;
using UnityEngine;

namespace Systems.Data
{
    public class TimerData : BaseData
    {
        public float MaxValue { get; set; }
        public float CurrentTime { get; set; }
        public float InitialTime { get; private set; }
        public bool IsActive { get; set; }
        
        public void StartTimer(float duration)
        {
            InitialTime = duration;
            CurrentTime = duration;
            IsActive = true;
        }
        
        public void PauseTimer()
        {
            IsActive = false;
        }
        
        public void ResumeTimer()
        {
            IsActive = true;
        }
        
        public void ResetTimer()
        {
            CurrentTime = InitialTime;
            IsActive = false;
        }
        
        public float GetProgress()
        {
            if (InitialTime <= 0f) return 0f;
            return 1f - (CurrentTime / InitialTime);
        }

        public override void Clear()
        {
            
        }
    }
}
