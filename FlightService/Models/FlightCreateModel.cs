using System;

namespace FlightService.Models
{
    public class FlightCreateModel
    {
        public string FromAirportCode { get; set; }
        public string ToAirportCode { get; set; }
        public string Code { get; set; }
        public DateTime DepartureDateTimeUtc { get; set; }
        public int StopOverCount { get; set; }
        public int TotalDurationMinutes { get; set; }
    }
}