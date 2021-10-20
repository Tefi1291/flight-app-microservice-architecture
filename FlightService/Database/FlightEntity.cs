using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightService.Database
{
    public class FlightEntity
    {
        public FlightEntity()
        {
            Bookings = new HashSet<FlightBookingEntity>();
        }

        public Guid Id { get; set;}
        public string Code { get; set; }
        public string FromAirportCode { get; set;}
        public string ToAirportCode { get; set; }
        public DateTime DepartureDateTimeUtc  { get; set; }
        public int StopOverCount { get; set; }
        public int TotalDurationMinutes { get; set; }
        
        public virtual ICollection<FlightBookingEntity> Bookings { get; set; }

        public static void OnModelCreating(EntityTypeBuilder<FlightEntity> modelBuilder)
        {
            modelBuilder.ToTable("Flight");

            modelBuilder.HasKey(m => m.Id);
        } 
    }
}