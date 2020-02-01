using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure.Domain
{
    public class PressureReading
    {
        public int RawValue { get; set; }
        public double PSI { get; set; }
        public double BAR { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Sensor { get; set; }

        public PressureReading(string sensor, int rawValue, DateTimeOffset timeStamp)
        {
            RawValue = rawValue;
            TimeStamp = timeStamp;
            PSI = PressureCalculator.CalculatePSI(RawValue);
            BAR = PressureCalculator.CalculateBAR(RawValue);
            Sensor = sensor;
        }

        public string ToCsvString()
        {
            return $"{TimeStamp},{Sensor},{PSI},{BAR},{RawValue},";
        }
    }
}
