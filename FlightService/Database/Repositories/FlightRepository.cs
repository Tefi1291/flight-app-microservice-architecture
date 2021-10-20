using System.Threading.Tasks;
using Database.Repositories.Interfaces;
using FlightService.Database;
using FlightService.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DatabaseContext _databaseContext;
        
        public FlightRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Guid> AddFlightAsync(FlightCreateModel createModel)
        {
            var flightEntity = new FlightEntity
            {
                Id = Guid.NewGuid(),
                Code = createModel.Code,
                FromAirportCode = createModel.FromAirportCode,
                ToAirportCode = createModel.ToAirportCode,
                DepartureDateTimeUtc = createModel.DepartureDateTimeUtc,
                StopOverCount = createModel.StopOverCount,
                TotalDurationMinutes = createModel.TotalDurationMinutes
            };

            _databaseContext.Flights.Add(flightEntity);

            await _databaseContext.SaveChangesAsync();

            return flightEntity.Id;
        }

        public async Task<FlightDetailModel> GetFlightDetailAsync(Guid flightId)
        {
            var query = (
                from f in _databaseContext.Flights
                where f.Id == flightId
                select new FlightDetailModel
                {
                    Id = f.Id,
                    Code = f.Code,
                    FromAirportCode = f.FromAirportCode,
                    ToAirportCode = f.ToAirportCode,
                    StopOverCount = f.StopOverCount,
                    TotalDurationMinutes = f.TotalDurationMinutes
                });

            return await query.FirstOrDefaultAsync();
        }

        public async Task<FlightListModel> GetFlightListAsync(int page, int pageSize)
        {
            var query = (
                from f in _databaseContext.Flights
                orderby f.Code
                select new FlightListModel.FlightModel
                {
                    Id = f.Id,
                    Code = f.Code,
                    FromAirportCode = f.FromAirportCode,
                    ToAirportCode = f.ToAirportCode,
                });

            return new FlightListModel
            {
                Flights = await query
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync()
            };
        }
    }
}