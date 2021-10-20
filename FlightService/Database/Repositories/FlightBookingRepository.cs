using System;
using System.Threading.Tasks;
using Database.Repositories.Interfaces;
using FlightService.Database;
using FlightService.Enums;
using FlightService.Models;

namespace Database.Repositories
{
    public class FlightBookingRepository : IFlightBookingRepository
    {
        private readonly DatabaseContext _databaseContext;

        public FlightBookingRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Guid> AddFlightBookingAsync(FlightBookingCreateModel createModel)
        {
            var flightBookingId = Guid.NewGuid();

            var flightBookingEntity = new FlightBookingEntity
            {
                Id = flightBookingId,
                FlightId = createModel.FlightId,
                Status = FlightBookingStatus.Confirmed,
                CreatedUtc = DateTime.UtcNow,
                AmountPaid = createModel.AmountPaid,
                PassengerName = createModel.PassengerName
            };

            _databaseContext.FlightBookings.Add(flightBookingEntity);
            await _databaseContext.SaveChangesAsync();

            return flightBookingId;
        }
    }
}