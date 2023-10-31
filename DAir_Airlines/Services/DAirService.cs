using DAir_Airlines.Interfaces;
using Database.DTOs;
using Database.Interfaces;

namespace DAir_Airlines.Services
{
    public class DAirService : IDAirService
    {
        private IDAirRepository _repository;

        public DAirService(IDAirRepository dAirRepository) { 
            _repository = dAirRepository;
        }

        public FlightInfoDto GetFlightDetailsByCode(string flightCode) {
            var flightDetails = _repository.GetFlightDetailsByCode(flightCode);
            return flightDetails;
        }
    }
}
