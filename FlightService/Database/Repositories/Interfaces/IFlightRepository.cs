using System;
using System.Threading.Tasks;
using FlightService.Models;

namespace Database.Repositories.Interfaces
{
    public interface IFlightRepository
    {        
        Task<Guid> AddFlightAsync(FlightCreateModel createModel);
        
        Task<FlightDetailModel> GetFlightDetailAsync(Guid flightId);

        Task<FlightListModel> GetFlightListAsync(int page, int pageSize);

    }
}