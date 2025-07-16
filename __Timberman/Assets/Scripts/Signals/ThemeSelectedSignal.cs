using Data;

namespace Signals
{
    public readonly struct ThemeSelectedSignal
    {
        public ThemeData ThemeData { get; } 
        
        public ThemeSelectedSignal(ThemeData themeData)
        {
            ThemeData = themeData;
        }

    }
}