using System;

namespace FlightService.Models
{
    public class FlightBookingCreateModel
    {
        public Guid FlightId { get; set; }
        public decimal AmountPaid { get; set; }
        public string PassengerName { get; set; }
    }
}