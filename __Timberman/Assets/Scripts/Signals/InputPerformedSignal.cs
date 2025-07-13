namespace Signals
{
    public class InputPerformedSignal
    {
        public float Direction { get; }
     
        public InputPerformedSignal(float direction)
        {
            Direction = direction;
        }
    }
}