using RadioactivityMonitor;

namespace AlarmLib.Tests;

public class AlarmTest
{
    [Fact]
    public void Check_IfValueWithinRange_AlarmTurnsOff()
    {
        var fake = new FakeSensor(18.0);
        var alarm = new Alarm(fake);

        alarm.Check();

        Assert.False(alarm.AlarmOn);
        Assert.Equal(0, alarm.AlarmCount);
    }

    [Fact]
    public void Check_IfValueBelowLowThreshold_AlarmTurnsOn()
    {
        var fake = new FakeSensor(16.5);
        var alarm = new Alarm(fake);

        alarm.Check();

        Assert.True(alarm.AlarmOn);
        Assert.Equal(1, alarm.AlarmCount);
    }

    [Fact]
    public void Check_IfValueAboveHighThreshold_AlarmTurnsOnAndIncrements()
    {
        var fake = new FakeSensor(21.5); 
        var alarm = new Alarm(fake);

        alarm.Check();
        alarm.Check();
        alarm.Check();

        Assert.True(alarm.AlarmOn);
        Assert.Equal(3, alarm.AlarmCount);
    }

    [Fact]
    public void Check_IfValueIsExactlyLowThreshold_AlarmStaysOff()
    {
        var alarm = new Alarm(new FakeSensor(17.0));
        alarm.Check();
        Assert.False(alarm.AlarmOn);
    }

    [Fact]
    public void Check_IfValueIsExactlyHighThreshold_AlarmStaysOff()
    {
        var alarm = new Alarm(new FakeSensor(21.0));
        alarm.Check();
        Assert.False(alarm.AlarmOn);
    }

    [Fact]
    public void Alarm_BeforeAnyCheck_ShouldBeOffByDefault()
    {
        var alarm = new Alarm(new FakeSensor(19.0));
        Assert.False(alarm.AlarmOn);
    }
}