using DAir_Airlines.Interfaces;
using Database.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DAir_Airlines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DAirController : Controller
    {
        private readonly ILogger<DAirController> _logger;
        public readonly IDAirService _dAirservice;

        public DAirController(ILogger<DAirController> logger, IDAirService dAirService)
        {
            _logger = logger;
            _dAirservice = dAirService;
        }

        /// <summary>
        /// 1. Given a flight code, get its state, departure and arrival airport and expected times
        /// </summary>
        [HttpGet]
        [Route("FirstQuery")]
        public IActionResult GetFirstQuery(string flightCode)
        {
            var flightInfo = _dAirservice.GetFlightDetailsByCode(flightCode);
            return Ok(flightInfo);
        }

        /// <summary>
        /// 2. Get the list of crew members available in a certain airport certified to fly an Airbus 350
        /// </summary>
        [HttpGet]
        [Route("SecondQuery")]
        public IActionResult GetSecondQuery(string airportCode)
        {
            var crewMembers = _dAirservice.GetCertifiedCrewMembersForAirbusA350AtAirport(airportCode);
            return Ok(crewMembers);
        }

        /// <summary>
        /// 3. Get the number of canceled flights
        /// </summary>
        [HttpGet]
        [Route("ThirdQuery")]
        public async Task<IActionResult> GetThirdQuery()
        {
            return Ok();
        }

        /// <summary>
        /// 4. Produce a table containing the number of flights each employee is scheduled from each airport (ascending order)
        /// </summary>
        [HttpGet]
        [Route("FourthQuery")]
        public async Task<IActionResult> GetFourthQuery()
        {
            return Ok();
        }

        /// <summary>
        /// 5. Get the average rating a pilot has given to its colleagues
        /// </summary>
        [HttpGet]
        [Route("FifthQuery")]
        public async Task<IActionResult> GetFifthQuery()
        {
            return Ok();
        }

        /// <summary>
        /// 6. Get the list of the languages spoken by a cabin crew member
        /// </summary>
        [HttpGet]
        [Route("SixthQuery")]
        public async Task<IActionResult> GetSixthQuery()
        {
            return Ok();
        }

        /// <summary>
        /// 7. Get the average rating given to each cabin crew member by pilots (order by descending rating)
        /// </summary>
        [HttpGet]
        [Route("SeventhQuery")]
        public async Task<IActionResult> GetSeventhQuery()
        {
            return Ok();
        }
    }
}
