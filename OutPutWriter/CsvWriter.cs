using Domain.Models;
using OutPutWriter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutPutWriter
{
    public class CsvWriter : IOutputWriter
    {
        public string Folder { get; set; }
        
        public CsvWriter(string folder)
        {
            Folder = folder; 
        }

        bool Write(string data)
        {
            try
            {
                System.IO.File.WriteAllText(Folder + GetFileName(), data);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool SavePressureReadings(IList<PressureReading> readings)
        {
            var stringBuilder = new StringBuilder();

            foreach(var reading in readings)
                stringBuilder.AppendLine(BuildLineFromReading(reading));

            return Write(stringBuilder.ToString());
        }

        string BuildLineFromReading(PressureReading reading)
        {
            return $"{reading.SensorName},{reading.TimeStamp},{reading.PSI},{reading.BAR},{reading.RawValue}";
        }

        string GetFileName()
        {
            return $"PressureReadings-{DateTimeOffset.Now}.txt";
        }
    }
}
