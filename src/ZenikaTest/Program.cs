using AlarmLib;
using RadioactivityMonitor;

var alarm = new Alarm(); //test the real sensor
for (int i = 0; i < 5; i++)
{
    alarm.Check();
    Console.WriteLine($"Check {i + 1}: AlarmOn={alarm.AlarmOn}, AlarmCount={alarm.AlarmCount}");
}