using HortaManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HortaManager.Infrastructure.EntityContext
{
    public class SqlDatabaseContext: DbContext
    {
        public SqlDatabaseContext(DbContextOptions<SqlDatabaseContext> options) : base(options)
        {
        }

        public DbSet<HortaReport> HortaReports { get; set; }
        public DbSet<ArduinoDevice> ArduinoDevice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArduinoDevice>()
                .HasIndex(a => a.Code)
                .IsUnique();
        }

    }
}
