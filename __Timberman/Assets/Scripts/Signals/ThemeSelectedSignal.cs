using Data;

namespace Signals
{
    public class ThemeSelectedSignal
    {
        public ThemeData ThemeData { get; } 
        
        public ThemeSelectedSignal(ThemeData themeData)
        {
            ThemeData = themeData;
        }

    }
}