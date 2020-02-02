using System;

namespace Domain.Models
{
    public class PressureReading
    {
        public int RawValue { get; set; }
        public double PSI { get; set; }
        public double BAR { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string SensorName { get; set; }        
    }
}
