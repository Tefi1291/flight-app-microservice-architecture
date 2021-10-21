using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlightBookingService.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class FlightBookingController : ControllerBase
    {

        public FlightBookingController()
        {
        }

        [HttpPost]
        public ActionResult Post()
        {
            Console.WriteLine("In POST request...");

            return new OkResult();
        }
    }
}
