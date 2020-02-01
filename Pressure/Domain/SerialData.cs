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

        public SerialData(DateTimeOffset timeStamp, string rawData)
        {
            TimeStamp = timeStamp;
            RawData = rawData;
        }
    }
}
