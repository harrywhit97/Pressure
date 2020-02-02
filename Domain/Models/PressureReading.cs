using System;

namespace Domain.Models
{
    public class PressureReading
    {
        public long Id { get; set; }
        public int RawValue { get; set; }
        public double PSI { get; set; }
        public double BAR { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string SensorName { get; set; }        
    }
}
