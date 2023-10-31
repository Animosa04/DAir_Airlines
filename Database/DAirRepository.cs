using Database.DTOs;
using Database.Interfaces;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
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
                                               ScheduledDepartureTime = f.ScheduledDepartureTime,
                                               ScheduledArrivalTime = f.ScheduledArrivalTime
                                           })
                                     .FirstOrDefault();

            return flightInfo;
        }

        public List<string> GetCertifiedCrewMembersForAirbusA350AtAirport(string airportCode)
        {
            var crewNames = _context.Pilots
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
                                    .Select(pepcdt => pepcdt.PilotEmployeeCertification.PilotEmployee.Employee.EmployeeName)
                                    .Distinct()
                                    .ToList();

            return crewNames.ToList();
        }
    }

    
}
