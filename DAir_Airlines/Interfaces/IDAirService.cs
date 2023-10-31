using Database.DTOs;

namespace DAir_Airlines.Interfaces
{
    public interface IDAirService
    {
        public FlightInfoDto GetFlightDetailsByCode(string flightCode);
        public List<string> GetCertifiedCrewMembersForAirbusA350AtAirport(string airportCode);
    }
}
