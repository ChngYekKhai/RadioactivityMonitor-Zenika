using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmLib.Tests
{
    public class FakeSensor : ISensor
    {
        public double returnValue;
        public FakeSensor(double value) { returnValue = value; }
        public double NextMeasure() => returnValue;
    }
}
