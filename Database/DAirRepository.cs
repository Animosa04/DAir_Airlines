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
    }

    
}
