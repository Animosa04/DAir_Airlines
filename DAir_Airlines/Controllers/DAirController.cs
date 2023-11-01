using DAir_Airlines.Interfaces;
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
        public IActionResult GetThirdQuery()
        {
            var numberOfCancelledFlights = _dAirservice.GetNumberOfCanceledFlights();
            return Ok(numberOfCancelledFlights);
        }

        /// <summary>
        /// 4. Produce a table containing the number of flights each employee is scheduled from each airport (ascending order)
        /// </summary>
        [HttpGet]
        [Route("FourthQuery")]
        public IActionResult GetFourthQuery()
        {
            var employeeFlights = _dAirservice.GetEmployeeFlightCountFromAirports();
            return Ok(employeeFlights);
        }

        /// <summary>
        /// 5. Get the average rating a pilot has given to its colleagues
        /// </summary>
        [HttpGet]
        [Route("FifthQuery")]
        public IActionResult GetFifthQuery(string pilotLicenseNumber)
        {
            var averageRating = _dAirservice.GetAverageRatingByPilot(pilotLicenseNumber);
            return Ok(averageRating);
        }

        /// <summary>
        /// 6. Get the list of the languages spoken by a cabin crew member
        /// </summary>
        [HttpGet]
        [Route("SixthQuery")]
        public IActionResult GetSixthQuery(string cabinCrewMemberNumber)
        {
            var languages = _dAirservice.GetLanguagesByCabinCrewMember(cabinCrewMemberNumber);
            return Ok(languages);
        }

        /// <summary>
        /// 7. Get the average rating given to each cabin crew member by pilots (order by descending rating)
        /// </summary>
        [HttpGet]
        [Route("SeventhQuery")]
        public IActionResult GetSeventhQuery()
        {
            var cabinCrewRatings = _dAirservice.GetAverageRatingsForCabinCrew();
            return Ok(cabinCrewRatings);
        }
    }
}
