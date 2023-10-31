using Database.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IDAirRepository
    {
        public FlightInfoDto GetFlightDetailsByCode(string flightCode);
        public List<string> GetCertifiedCrewMembersForAirbusA350AtAirport(string airportCode);
        public int GetNumberOfCanceledFlights();
    }
}
