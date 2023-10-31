﻿using DAir_Airlines.Interfaces;
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

        public List<string> GetCertifiedCrewMembersForAirbusA350AtAirport(string airportCode)
        {
            var crewMembers = _repository.GetCertifiedCrewMembersForAirbusA350AtAirport(airportCode);
            return crewMembers;
        }

        public int GetNumberOfCanceledFlights()
        {
            var numberOfCancelledFlights = _repository.GetNumberOfCanceledFlights();
            return numberOfCancelledFlights;
        }
    }
}
