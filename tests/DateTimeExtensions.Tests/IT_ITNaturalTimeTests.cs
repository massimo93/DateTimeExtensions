using System;
using DateTimeExtensions.NaturalText;
using NUnit.Framework;

namespace DateTimeExtensions.Tests;

[TestFixture]
public class IT_ITNaturalTimeTests
{
    private readonly NaturalTextCultureInfo _italianNaturalTextCultureInfo = new NaturalTextCultureInfo("it-IT");
    private readonly DateTime _fromTime = new DateTime(2024, 7, 16, 10, 30, 0);

    [Test]
    public void CanTranslateToNaturalText()
    {
        var toTime = _fromTime.AddHours(2);
        var naturalText = _fromTime.ToNaturalText(toTime, false, _italianNaturalTextCultureInfo);
        
        Assert.That(naturalText, Is.Not.Null);
        Assert.That(naturalText, Is.Not.Empty);
        Assert.That(naturalText, Is.EqualTo("2 ore"));
    }
    
    [Test]
    public void CanTranslateToRoundedNaturalText()
    {
        var toTime = _fromTime.AddHours(2).AddMinutes(45);
        var naturalText = _fromTime.ToNaturalText(toTime, true, _italianNaturalTextCultureInfo);
        
        Assert.That(naturalText, Is.Not.Null);
        Assert.That(naturalText, Is.Not.Empty);
        Assert.That(naturalText, Is.EqualTo("3 ore"));
    }
    
    [Test]
    public void CanTranslateToExactNaturalText()
    {
        var toTime = _fromTime.AddHours(2).AddMinutes(45);
        var naturalText = _fromTime.ToExactNaturalText(toTime, _italianNaturalTextCultureInfo);
        
        Assert.That(naturalText, Is.Not.Null);
        Assert.That(naturalText, Is.Not.Empty);
        Assert.That(naturalText, Is.EqualTo("2 ore, 45 minuti"));
    }
    
    [Test]
    public void CanTranlateToExactNaturaTextFull_Plural()
    {
        var toTime = _fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

        var naturalText = _fromTime.ToExactNaturalText(toTime, _italianNaturalTextCultureInfo);

        Assert.That(naturalText, Is.Not.Null);
        Assert.That(naturalText, Is.Not.Empty);
        Assert.That(naturalText, Is.EqualTo("2 anni, 2 mesi, 3 giorni, 4 ore, 5 minuti, 6 secondi"));
    }
    
    [Test]
    public void CanTranlateToExactNaturaTextFull_Singular()
    {
        var toTime = _fromTime.AddSeconds(1).AddMinutes(1).AddHours(1).AddDays(1).AddMonths(1).AddYears(1);

        var naturalText = _fromTime.ToExactNaturalText(toTime, _italianNaturalTextCultureInfo);

        Assert.That(naturalText, Is.Not.Null);
        Assert.That(naturalText, Is.Not.Empty);
        Assert.That(naturalText, Is.EqualTo("1 anno, 1 mese, 1 giorno, 1 ora, 1 minuto, 1 secondo"));
    }
}