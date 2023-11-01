using Database.DTOs;

namespace Database.Interfaces
{
    public interface IDAirRepository
    {
        public FlightInfoDto GetFlightDetailsByCode(string flightCode);
        public List<string> GetCertifiedCrewMembersForAirbusA350AtAirport(string airportCode);
        public int GetNumberOfCanceledFlights();
        public List<EmployeeFlightCountDto> GetEmployeeFlightCountFromAirports();
        public double GetAverageRatingByPilot(string pilotLicenseNumber);
        public List<string> GetLanguagesByCabinCrewMember(string cabinCrewMemberNumber);
        public List<CabinCrewRatingDto> GetAverageRatingsForCabinCrew();
    }
}
