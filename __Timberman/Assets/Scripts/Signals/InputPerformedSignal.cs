namespace Signals
{
    public readonly struct InputPerformedSignal
    {
        public float Direction { get; }
     
        public InputPerformedSignal(float direction)
        {
            Direction = direction;
        }
    }
}