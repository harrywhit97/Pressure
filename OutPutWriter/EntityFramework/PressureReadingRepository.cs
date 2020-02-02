using Domain.Models;
using OutPutWriter.Interfaces;
using System.Collections.Generic;

namespace Pressure.EF
{
    public class PressureReadingRepository : IOutputWriter
    {
        public bool SavePressureReadings(IList<PressureReading> readings)
        {
            try
            {
                using (var db = new PressureDbContext())
                {
                    db.PressureReadings.AddRange(readings);
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
