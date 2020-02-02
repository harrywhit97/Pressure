using Domain.Models;
using System.Collections.Generic;

namespace OutPutWriter.Interfaces
{
    public interface IOutputWriter
    {
        bool SavePressureReadings(IList<PressureReading> readings);
    }
}
