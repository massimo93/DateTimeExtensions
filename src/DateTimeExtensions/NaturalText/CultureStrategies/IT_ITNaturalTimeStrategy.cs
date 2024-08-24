using System.Linq;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.NaturalText.CultureStrategies
{
    [Locale("it-IT")]
    public class IT_ITNaturalTimeStrategy : NaturalTimeStrategyBase
    {
        protected override string YearText => "anno";
        
        protected override string MonthText => "mese";
        
        protected override string DayText => "giorno";
        
        protected override string HourText => "ora";
        
        protected override string MinuteText => "minuto";
        
        protected override string SecondText => "secondo";

        protected override string Pluralize(string text, int value)
            => text.Substring(0, text.Length - 1) + (text.EndsWith("a") ? 'e' : 'i');
    }
}