using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Pressure.EF
{
    public class PressureDbContext : DbContext
    {
        public DbSet<PressureReading> PressureReadings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\mssqllocaldb;Database=Pressure;Integrated Security=True");
        }


    }
}
