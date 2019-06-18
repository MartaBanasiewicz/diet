using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przepisy_i_powiadomienia
{
    public class PoradnikContext : DbContext
    {
        public DbSet<Target> Targets { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=poradnik.db");
        }
    }

    
        public class Target
        {
            public int TargetId { get; set; }
            public int Weight { get; set; }
            public int Water { get; set; }
            public int Calories { get; set; }
            public int Distance { get; set; }
        }

        public class Measurement
        {
            public int MeasurementId { get; set; }
            public int Weight { get; set; }
            public int Water { get; set; }
            public int Calories { get; set; }
            public int Distance { get; set; }
            public DateTime DateTime { get; set; }
    }

    
}
