using Domain.Models;
using OutPutWriter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pressure.EF
{
    public class PressureReadingRepository : IOutputWriter
    {

        public bool SavePressureReadings(IList<PressureReading> readings)
        {
            try
            {
                using var db = new PressureDbContext();
                db.PressureReadings.AddRange(readings);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public PressureReading GetRecords()
        {
            using var db = new PressureDbContext();
            return db.PressureReadings.FirstOrDefault(); ;
        }
    }
}
