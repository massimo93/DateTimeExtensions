using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests;

[TestFixture]
public class IT_ITHolidaysTests
{
    [Test]
    public void CanGetHolidayStrategy()
    {
        var dateTimeCulture = new WorkingDayCultureInfo("it-IT");
        var holidaysStrategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);
        Assert.That(holidaysStrategy.GetType(), Is.EqualTo(typeof(IT_ITHolidayStrategy)));
    }
}