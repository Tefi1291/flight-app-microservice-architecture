using System;
using FlightService.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightService.Database
{
    public class FlightBookingEntity
    {
        public FlightBookingEntity()
        {
            
        }

        public Guid Id { get; set;}
        public Guid FlightId { get; set; }
        public FlightBookingStatus Status { get; set; }
        public DateTime CreatedUtc { get; set; }
        public decimal AmountPaid { get; set; }
        public string PassengerName { get; set; }
        
        public virtual FlightEntity Flight { get;set; }

        public static void OnModelCreating(EntityTypeBuilder<FlightBookingEntity> modelBuilder)
        {
            modelBuilder.ToTable("FlightBooking");

            modelBuilder.HasKey(m => m.Id);

            modelBuilder
                .HasOne(m => m.Flight)
                .WithMany(m => m.Bookings)
                .HasForeignKey(m => m.FlightId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Property(m => m.AmountPaid)
                .HasPrecision(18, 2);
        } 
    }
}