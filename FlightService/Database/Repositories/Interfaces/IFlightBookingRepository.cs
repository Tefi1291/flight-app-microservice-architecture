using System;
using System.Threading.Tasks;
using FlightService.Models;

namespace Database.Repositories.Interfaces
{
    public interface IFlightBookingRepository
    {        
        Task<Guid> AddFlightBookingAsync(FlightBookingCreateModel createModel);
    }
}