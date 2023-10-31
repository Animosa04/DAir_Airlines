using Database.DTOs;

namespace DAir_Airlines.Interfaces
{
    public interface IDAirService
    {
        public FlightInfoDto GetFlightDetailsByCode(string flightCode);
    }
}
