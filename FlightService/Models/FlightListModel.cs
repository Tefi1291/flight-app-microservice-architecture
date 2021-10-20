using System;

namespace FlightService.Models 
{
    public class FlightListModel
    {
        public FlightModel[] Flights { get; set; }
        
        public class FlightModel
        {
            public Guid Id { get; set; }
            public string Code { get; set; }
            public string FromAirportCode { get; set; }
            public string ToAirportCode { get; set; }            
        }
    }
}