﻿using Database.DTOs;

namespace DAir_Airlines.Interfaces
{
    public interface IDAirService
    {
        public FlightInfoDto GetFlightDetailsByCode(string flightCode);
        public List<PilotInfoDto> GetCertifiedCrewMembersForAirbusA350AtAirport(string airportCode);
        public int GetNumberOfCanceledFlights();
        public List<EmployeeFlightCountDto> GetEmployeeFlightCountFromAirports();
        public double GetAverageRatingByPilot(string pilotLicenseNumber);
        public List<string> GetLanguagesByCabinCrewMember(string cabinCrewMemberNumber);
        public List<CabinCrewRatingDto> GetAverageRatingsForCabinCrew();
    }
}
