using Systems.Data.Abstractions;

namespace Systems.Data
{
    public class TimerData : BaseData
    {
        public float MaxTime { get; set; }
        public float CurrentTime { get; set; }

        public override void Clear() { }
    }
}
