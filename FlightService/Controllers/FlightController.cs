using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Repositories.Interfaces;
using FlightService.Clients.Interfaces;
using FlightService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightController : ControllerBase
    {
        private readonly IApiHttpClient _apiHttpClient;
        private readonly IConfiguration _configuration;
        private readonly IFlightRepository _flightRepository;
        private readonly IFlightBookingRepository _flightBookingRepository;
    
        public FlightController(
            IApiHttpClient apiHttpClient,
            IConfiguration configuration,
            IFlightRepository flightRepository,
            IFlightBookingRepository flightBookingRepository)
        {
            _apiHttpClient = apiHttpClient;
            _configuration = configuration;
            _flightRepository = flightRepository;
            _flightBookingRepository = flightBookingRepository;
        }

        [HttpPost]
        [Route("")]
        public async Task<Guid> CreateFlightAsync([FromBody] FlightCreateModel flightCreateModel)
        {
            //verify 

            var flightId = await _flightRepository.AddFlightAsync(flightCreateModel);
            return flightId;
        }

        [HttpGet]
        [Route("{flightId:Guid}")]
        public async Task<ActionResult> GetFlightDetailAsync(Guid flightId)
        {
            var flightDetailModel = await _flightRepository.GetFlightDetailAsync(flightId);
            
            return (flightDetailModel is null) 
                ? NotFound() 
                : new OkObjectResult(flightDetailModel);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetFlightListAsync([FromQuery] int page)
        {
            var flightList = await _flightRepository.GetFlightListAsync(page, 15);

            return new OkObjectResult(flightList);
        }
        

        [HttpPost]
        [Route("bookings")]
        public async Task<Guid> CreateFlightBookingAsync([FromBody] FlightBookingCreateModel flightBookingCreateModel)
        {
            //verify 
            var flightBookingId = await _flightBookingRepository.AddFlightBookingAsync(flightBookingCreateModel);
            
            var url = _configuration["API:FlightBookingServiceUrl"];

            Console.WriteLine($"Sending to {url}...");
            await _apiHttpClient.SendPostAsync(url, null);
            
            return flightBookingId;
        }
    }
}
