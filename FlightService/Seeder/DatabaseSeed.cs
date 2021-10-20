using System;
using FlightService.Database;

namespace FlightService.Seeder
{
    public static class DatabaseSeed 
    {
        public static void Seed(this DatabaseContext databaseContext)
        {
            databaseContext.Flights.AddRange(new []
            {
                new FlightEntity 
                {
                    Code = "Test-000",
                    FromAirportCode = "MAD",
                    ToAirportCode = "BCN",
                    DepartureDateTimeUtc = DateTime.UtcNow.AddDays(7),
                    StopOverCount = 0,
                    TotalDurationMinutes = 60,
                }
            });

            databaseContext.SaveChanges();
        }
    }
}