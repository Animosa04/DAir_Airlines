using DAir_Airlines.Interfaces;
using DAir_Airlines.Models;
using DAir_Airlines.Security;
using Database.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ILogger = Serilog.ILogger;

namespace DAir_Airlines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DAirController : Controller
    {
        private readonly ILogger _logger;
        public readonly IDAirService _dAirservice;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMongoClient _mongoClient;

        public DAirController(ILogger logger, IDAirService dAirService, UserManager<IdentityUser> userManager, IMongoClient mongoClient, IConfiguration configuration)
        {
            _logger = logger;
            _dAirservice = dAirService;
            _userManager = userManager;
            _mongoClient = mongoClient;
            _configuration = configuration;
        }

        /// <summary>
        /// 1. Given a flight code, get its state, departure and arrival airport and expected times
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Crew,Pilot")]
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
        [Authorize(Roles = "Admin,Crew,Pilot")]
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
        [Authorize(Roles = "Admin,Crew,Pilot")]
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
        [Authorize(Roles = "Admin,Crew,Pilot")]
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
        [Authorize(Roles = "Admin,Crew,Pilot")]
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
        [Authorize(Roles = "Admin,Crew,Pilot")]
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
        [Authorize(Roles = "Admin,Crew,Pilot")]
        [Route("SeventhQuery")]
        public IActionResult GetSeventhQuery()
        {
            var cabinCrewRatings = _dAirservice.GetAverageRatingsForCabinCrew();
            return Ok(cabinCrewRatings);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel model, string roleName)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            // Assign role
            if (!string.IsNullOrEmpty(roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                // Add role claims
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("PilotConflicts")]
        [Authorize(Roles = "Pilot")]
        public async Task<IActionResult> GetPilotConflicts()
        {
            var conflicts = await _dAirservice.GetAllPilotConflictsAsync();
            return Ok(conflicts);
        }


        [HttpPost]
        [Route("PilotConflicts")]
        [Authorize(Roles = "Pilot")]
        public async Task<IActionResult> CreatePilotConflict([FromBody] PilotConflictsDto pilotConflict)
        {
            _logger.ForContext("Username", User.Identity.Name)
                   .ForContext("OperationType", "POST")
                   .Warning("Creating a new pilot conflict");
            var createdConflict = await _dAirservice.CreatePilotConflictAsync(pilotConflict);
            return CreatedAtAction(nameof(GetPilotConflicts), new { conflictId = createdConflict.ConflictID }, createdConflict);
        }


        [HttpPut]
        [Route("PilotConflicts/{conflictId}")]
        [Authorize(Roles = "Pilot")]
        public async Task<IActionResult> UpdatePilotConflict(int conflictId, [FromBody] PilotConflictsDto pilotConflict)
        {
            _logger.ForContext("Username", User.Identity.Name)
                   .ForContext("OperationType", "PUT")
                   .Warning("Updating pilot conflict");
            var updatedConflict = await _dAirservice.UpdatePilotConflictAsync(conflictId, pilotConflict);
            if (updatedConflict == null)
            {
                return NotFound();
            }
            return Ok(updatedConflict);
        }


        [HttpDelete]
        [Route("PilotConflicts/{conflictId}")]
        [Authorize(Roles = "Pilot")] // Only pilots can access
        public async Task<IActionResult> DeletePilotConflict(int conflictId)
        {
            _logger.ForContext("Username", User.Identity.Name)
                   .ForContext("OperationType", "DELETE")
                   .Warning("Deleting pilot conflict");
            var deleted = await _dAirservice.DeletePilotConflictAsync(conflictId);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        [Route("CabinCrewLanguages")]
        [Authorize(Roles = "Crew")]
        public async Task<IActionResult> CreateCabinCrewLanguage([FromBody] CabinCrewLanguagesDto cabinCrewLanguage)
        {
            _logger.ForContext("Username", User.Identity.Name)
                   .ForContext("OperationType", "POST")
                   .Warning("Creating a new cabin crew language");
            var createdLanguage = await _dAirservice.CreateCabinCrewLanguageAsync(cabinCrewLanguage);
            return CreatedAtAction(nameof(GetSixthQuery), new { crewMemberNumber = createdLanguage.CabinCrewMemberNumber, languageId = createdLanguage.LanguageID }, createdLanguage);
        }

        [HttpPut]
        [Route("CabinCrewLanguages/{crewMemberNumber}/{languageId}")]
        [Authorize(Roles = "Crew")]
        public async Task<IActionResult> UpdateCabinCrewLanguage(int crewMemberLanguageId, [FromBody] CabinCrewLanguagesDto cabinCrewLanguage)
        {
            _logger.ForContext("Username", User.Identity.Name)
                   .ForContext("OperationType", "PUT")
                   .Warning("Updating cabin crew language");
            var updatedLanguage = await _dAirservice.UpdateCabinCrewLanguageAsync(crewMemberLanguageId, cabinCrewLanguage);
            if (updatedLanguage == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("CabinCrewLanguages/{crewMemberNumber}/{languageId}")]
        [Authorize(Roles = "Crew")]
        public async Task<IActionResult> DeleteCabinCrewLanguage(string crewMemberNumber, int languageId)
        {
            _logger.ForContext("Username", User.Identity.Name)
                   .ForContext("OperationType", "DELETE")
                   .Warning("Deleting cabin crew language for crew member");
            var success = await _dAirservice.DeleteCabinCrewLanguageAsync(crewMemberNumber, languageId);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("search")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchLogs([FromQuery] LogSearchModel searchModel)
        {
            var logCollection = _mongoClient.GetDatabase("DAirLogs").GetCollection<LogDto>("Logs");

            var filterBuilder = Builders<LogDto>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrWhiteSpace(searchModel.Username))
            {
                filter &= filterBuilder.Eq(log => log.Properties.Username, searchModel.Username);
            }
            if (searchModel.StartTime.HasValue && searchModel.EndTime.HasValue)
            {
                filter &= filterBuilder.Gte(log => log.Timestamp, searchModel.StartTime.Value) &
                          filterBuilder.Lte(log => log.Timestamp, searchModel.EndTime.Value);
            }
            if (!string.IsNullOrWhiteSpace(searchModel.OperationType))
            {
                filter &= filterBuilder.Eq(log => log.Properties.OperationType, searchModel.OperationType);
            }

            var logs = await logCollection.Find(filter).ToListAsync();

            return Ok(logs);
        }





        [HttpGet("searchNoFilter")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchLogsNoFilter([FromQuery] LogSearchModel searchModel)
        {
            var logCollection = _mongoClient.GetDatabase("DAirLogs").GetCollection<BsonDocument>("Logs"); // Replace with your log collection name

            var filter = Builders<BsonDocument>.Filter.Empty;

            var logs = await logCollection.Find(filter).ToListAsync();

            return Ok(logs);
        }
    }
}
