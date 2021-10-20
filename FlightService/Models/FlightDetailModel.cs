using System;

namespace FlightService.Models 
{
    public class FlightDetailModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string FromAirportCode { get; set; }
        public string ToAirportCode { get; set; }   
        public int StopOverCount { get; set; }
        public int TotalDurationMinutes { get; set; }      
    }
}