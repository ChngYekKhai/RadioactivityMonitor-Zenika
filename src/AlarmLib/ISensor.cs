using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmLib
{
    public interface ISensor
    {
        double NextMeasure();
    }
}
