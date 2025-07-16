using Data;

namespace Signals
{
    public struct ThemeSelectedSignal
    {
        public ThemeData ThemeData { get; } 
        
        public ThemeSelectedSignal(ThemeData themeData)
        {
            ThemeData = themeData;
        }

    }
}