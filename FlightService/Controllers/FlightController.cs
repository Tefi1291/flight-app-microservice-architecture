using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Repositories.Interfaces;
using FlightService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IFlightBookingRepository _flightBookingRepository;

        public FlightController(
            IFlightRepository flightRepository,
            IFlightBookingRepository flightBookingRepository)
        {
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
        [Route("booking")]
        public async Task<Guid> CreateFlightBookingAsync([FromBody] FlightBookingCreateModel flightBookingCreateModel)
        {
            //verify 
            var flightBookingId = await _flightBookingRepository.AddFlightBookingAsync(flightBookingCreateModel);
            
            return flightBookingId;
        }
    }
}
