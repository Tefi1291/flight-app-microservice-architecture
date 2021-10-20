using Microsoft.EntityFrameworkCore;

namespace FlightService.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<FlightEntity> Flights { get; set; }
        public DbSet<FlightBookingEntity> FlightBookings { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FlightEntity.OnModelCreating(modelBuilder.Entity<FlightEntity>());
            FlightBookingEntity.OnModelCreating(modelBuilder.Entity<FlightBookingEntity>());
        }
    }
}