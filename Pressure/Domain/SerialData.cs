using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure.Domain
{
    public class SerialData
    {
        public DateTimeOffset TimeStamp { get; set; }
        public string RawData { get; set; }

        public Dictionary<string, int> Data { get; set; }

        public SerialData(DateTimeOffset timeStamp, string rawData)
        {
            TimeStamp = timeStamp;
            RawData = rawData;
            Data = new Dictionary<string, int>();
            Decode();
        }

        Dictionary<string, int> Decode()
        {
            var dataSeparated = RawData.Split(',');

            for (int i = 0; i < dataSeparated.Length; i += 2)
            {
                var readingString = dataSeparated[i + 1];

                if (!int.TryParse(readingString, out int reading))
                    throw new Exception($"Reading {readingString} is not an integer");

                Data.Add(dataSeparated[i], reading);
            }
            return Data;
        }

    }
}
