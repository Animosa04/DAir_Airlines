using Database.DTOs;
using Database.Interfaces;
using System.Globalization;

namespace Database.Repositories
{
    public class DAirRepository : IDAirRepository
    {
        private readonly DAirDatabaseContext _context;

        public DAirRepository(DAirDatabaseContext context)
        {
            _context = context;
        }

        public FlightInfoDto GetFlightDetailsByCode(string flightCode)
        {
            var flightInfo = _context.Flights
                                     .Where(f => f.FlightCode == flightCode)
                                     .Join(_context.FlightStates,
                                           f => f.CurrentStateID,
                                           fs => fs.StateID,
                                           (f, fs) => new FlightInfoDto
                                           {
                                               StateName = fs.StateName,
                                               DepartureAirport = f.DepartureAirport,
                                               DestinationAirport = f.DestinationAirport,
                                               ScheduledDepartureTime = DateTime.ParseExact(f.ScheduledDepartureTime, "ddMMyyyy HHmm", CultureInfo.InvariantCulture),
                                               ScheduledArrivalTime = DateTime.ParseExact(f.ScheduledArrivalTime, "ddMMyyyy HHmm", CultureInfo.InvariantCulture)
                                           })
                                     .FirstOrDefault();

            return flightInfo;
        }

        public List<PilotInfoDto> GetCertifiedCrewMembersForAirbusA350AtAirport(string airportCode)
        {
            var crewMembers = _context.Pilots
                           .Join(_context.Employees,
                                 p => p.PilotEmployeeNumber,
                                 e => e.EmployeeNumber,
                                 (p, e) => new { Pilot = p, Employee = e })
                           .Join(_context.PilotCertifications,
                                 pe => pe.Pilot.PilotLicenseNumber,
                                 pc => pc.PilotLicenseNumber,
                                 (pe, pc) => new { PilotEmployee = pe, PilotCertification = pc })
                           .Join(_context.DailyTrips,
                                 pepc => pepc.PilotEmployee.Employee.EmployeeNumber,
                                 dt => dt.EmployeeNumber,
                                 (pepc, dt) => new { PilotEmployeeCertification = pepc, DailyTrip = dt })
                           .Where(pepcdt => pepcdt.PilotEmployeeCertification.PilotCertification.AircraftModel == "Airbus A350"
                                           && pepcdt.DailyTrip.BaseAirport == airportCode)
                           .Select(pepcdt => new PilotInfoDto
                           {
                               PilotName = pepcdt.PilotEmployeeCertification.PilotEmployee.Employee.EmployeeName,
                               PilotLicenseNumber = pepcdt.PilotEmployeeCertification.PilotEmployee.Pilot.PilotLicenseNumber
                           })
                           .Distinct()
                           .ToList();

            return crewMembers;
        }

        public int GetNumberOfCanceledFlights()
        {
            var canceledFlightsCount = _context.Flights
                                               .Join(_context.FlightStates,
                                                     f => f.CurrentStateID,
                                                     fs => fs.StateID,
                                                     (f, fs) => new { Flight = f, FlightState = fs })
                                               .Where(joined => joined.FlightState.StateName == "Cancelled")
                                               .Count();

            return canceledFlightsCount;
        }

        public List<EmployeeFlightCountDto> GetEmployeeFlightCountFromAirports()
        {
            var flightCounts = _context.Employees
                                       .Join(
                                           _context.DailyTrips,
                                           e => e.EmployeeNumber,
                                           dt => dt.EmployeeNumber,
                                           (e, dt) => new { e.EmployeeName, dt.BaseAirport, dt.TripID }
                                       )
                                       .Join(
                                           _context.EmployeeAssignments,
                                           temp => temp.TripID,
                                           ea => ea.TripID,
                                           (temp, ea) => new { temp.EmployeeName, temp.BaseAirport }
                                       )
                                       .GroupBy(x => new { x.EmployeeName, x.BaseAirport })
                                       .Select(g => new EmployeeFlightCountDto
                                       {
                                           EmployeeName = g.Key.EmployeeName,
                                           BaseAirport = g.Key.BaseAirport,
                                           NumberOfFlights = g.Count()
                                       })
                                       .OrderBy(r => r.NumberOfFlights)
                                       .ToList();

            return flightCounts;
        }

        public double GetAverageRatingByPilot(string pilotLicenseNumber)
        {
            var pilotRatings = _context.PilotRatings
                                       .Where(pr => pr.RatingPilotLicenseNumber == pilotLicenseNumber)
                                       .ToList();

            if (pilotRatings.Any())
            {
                return pilotRatings.Average(pr => pr.Rating);
            }

            return 0.0;
        }

        public List<string> GetLanguagesByCabinCrewMember(string cabinCrewMemberNumber)
        {
            var languages = _context.CabinCrewMembers
                                    .Where(cc => cc.CabinCrewMemberNumber == cabinCrewMemberNumber)
                                    .Join(
                                        _context.CabinCrewLanguages,
                                        cc => cc.CabinCrewMemberNumber,
                                        ccl => ccl.CabinCrewMemberNumber,
                                        (cc, ccl) => ccl.LanguageID
                                    )
                                    .Join(
                                        _context.Languages,
                                        ccl => ccl,
                                        l => l.LanguageID,
                                        (ccl, l) => l.LanguageName
                                    )
                                    .ToList();

            return languages;
        }

        public List<CabinCrewRatingDto> GetAverageRatingsForCabinCrew()
        {
            var ratings = _context.PilotRatings
                                  .Join(
                                      _context.CabinCrewMembers,
                                      pr => pr.RatedCabinCrewMemberNumber,
                                      cc => cc.CabinCrewMemberNumber,
                                      (pr, cc) => new { pr.Rating, CabinCrewMemberNumber = cc.CabinCrewMemberNumber }
                                  )
                                  .GroupBy(x => x.CabinCrewMemberNumber)
                                  .Select(g => new CabinCrewRatingDto
                                  {
                                      CabinCrewMemberNumber = g.Key,
                                      AverageRating = g.Average(x => x.Rating)
                                  })
                                  .OrderByDescending(r => r.AverageRating)
                                  .ToList();

            return ratings;
        }


    }
}
