using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq;

namespace Pressure.EF
{
    public class PressureDbContext : DbContext
    {
        public DbSet<PressureReading> PressureReadings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database = test; Trusted_Connection = True; MultipleActiveResultSets = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
