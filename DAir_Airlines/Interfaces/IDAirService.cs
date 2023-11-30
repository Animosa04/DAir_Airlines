using Database.DTOs;

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
        Task<IEnumerable<PilotConflictsDto>> GetAllPilotConflictsAsync();
        Task<PilotConflictsDto> CreatePilotConflictAsync(PilotConflictsDto pilotConflict);
        Task<PilotConflictsDto> UpdatePilotConflictAsync(int conflictId, PilotConflictsDto pilotConflict);
        Task<bool> DeletePilotConflictAsync(int conflictId);
        Task<CabinCrewLanguagesDto> CreateCabinCrewLanguageAsync(CabinCrewLanguagesDto cabinCrewLanguage);
        Task<CabinCrewLanguagesDto> UpdateCabinCrewLanguageAsync(int crewMemberLanguageId, CabinCrewLanguagesDto cabinCrewLanguage);
        Task<bool> DeleteCabinCrewLanguageAsync(string crewMemberNumber, int languageId);
    }
}
