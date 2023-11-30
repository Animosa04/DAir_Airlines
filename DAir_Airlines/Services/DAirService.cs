using DAir_Airlines.Interfaces;
using Database;
using Database.DTOs;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAir_Airlines.Services
{
    public class DAirService : IDAirService
    {
        private IDAirRepository _repository;
        private readonly DAirDatabaseContext _context;


        public DAirService(DAirDatabaseContext context, IDAirRepository dAirRepository)
        {
            _repository = dAirRepository;
            _context = context;
        }

        public FlightInfoDto GetFlightDetailsByCode(string flightCode)
        {
            var flightDetails = _repository.GetFlightDetailsByCode(flightCode);
            return flightDetails;
        }

        public List<PilotInfoDto> GetCertifiedCrewMembersForAirbusA350AtAirport(string airportCode)
        {
            var crewMembers = _repository.GetCertifiedCrewMembersForAirbusA350AtAirport(airportCode);
            return crewMembers;
        }

        public int GetNumberOfCanceledFlights()
        {
            var numberOfCancelledFlights = _repository.GetNumberOfCanceledFlights();
            return numberOfCancelledFlights;
        }

        public List<EmployeeFlightCountDto> GetEmployeeFlightCountFromAirports()
        {
            var employeeFlights = _repository.GetEmployeeFlightCountFromAirports();
            return employeeFlights;
        }

        public double GetAverageRatingByPilot(string pilotLicenseNumber)
        {
            var averageRating = _repository.GetAverageRatingByPilot(pilotLicenseNumber);
            return averageRating;
        }

        public List<string> GetLanguagesByCabinCrewMember(string cabinCrewMemberNumber)
        {
            var languages = _repository.GetLanguagesByCabinCrewMember(cabinCrewMemberNumber);
            return languages;
        }

        public List<CabinCrewRatingDto> GetAverageRatingsForCabinCrew()
        {
            var cabinCrewRatings = _repository.GetAverageRatingsForCabinCrew();
            return cabinCrewRatings;
        }

        public async Task<IEnumerable<PilotConflictsDto>> GetAllPilotConflictsAsync()
        {
            var conflicts = await _context.PilotConflicts
                            .Select(conflict => new PilotConflictsDto
                            {
                                ConflictID = conflict.ConflictID,
                                PilotLicenseNumber = conflict.PilotLicenseNumber,
                                ConflicsWithPilot = conflict.ConflicsWithPilot
                            })
                            .ToListAsync();
            return conflicts;
        }

        public async Task<PilotConflictsDto> CreatePilotConflictAsync(PilotConflictsDto pilotConflict)
        {
            var newConflict = new PilotConflictsDto // Assuming this is your EF Core entity class
            {
                PilotLicenseNumber = pilotConflict.PilotLicenseNumber,
                ConflicsWithPilot = pilotConflict.ConflicsWithPilot
            };

            _context.PilotConflicts.Add(newConflict);
            await _context.SaveChangesAsync();

            pilotConflict.ConflictID = newConflict.ConflictID; // EF Core fills ID after saving
            return pilotConflict;
        }

        public async Task<PilotConflictsDto> UpdatePilotConflictAsync(int conflictId, PilotConflictsDto pilotConflict)
        {
            var existingConflict = await _context.PilotConflicts.FindAsync(conflictId);
            if (existingConflict == null)
            {
                return null;
            }

            existingConflict.PilotLicenseNumber = pilotConflict.PilotLicenseNumber;
            existingConflict.ConflicsWithPilot = pilotConflict.ConflicsWithPilot;

            _context.Update(existingConflict);
            await _context.SaveChangesAsync();

            return pilotConflict;
        }

        public async Task<bool> DeletePilotConflictAsync(int conflictId)
        {
            var conflict = await _context.PilotConflicts.FindAsync(conflictId);
            if (conflict == null)
            {
                return false;
            }

            _context.PilotConflicts.Remove(conflict);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CabinCrewLanguagesDto> CreateCabinCrewLanguageAsync(CabinCrewLanguagesDto cabinCrewLanguageDto)
        {
            var newLanguage = new CabinCrewLanguagesDto
            {
                CabinCrewMemberNumber = cabinCrewLanguageDto.CabinCrewMemberNumber,
                LanguageID = cabinCrewLanguageDto.LanguageID
            };

            _context.CabinCrewLanguages.Add(newLanguage);
            await _context.SaveChangesAsync();

            return cabinCrewLanguageDto; // Assuming the ID is not auto-generated
        }
        public async Task<CabinCrewLanguagesDto> UpdateCabinCrewLanguageAsync(int crewMemberLanguageId, CabinCrewLanguagesDto cabinCrewLanguageDto)
        {
            var language = await _context.CabinCrewLanguages.FindAsync(crewMemberLanguageId);
            if (language == null)
            {
                return null; // Language not found
            }

            language.LanguageID = cabinCrewLanguageDto.LanguageID;

            _context.Update(language);
            await _context.SaveChangesAsync();

            return cabinCrewLanguageDto;
        }

        public async Task<bool> DeleteCabinCrewLanguageAsync(string crewMemberNumber, int languageId)
        {
            var language = await _context.CabinCrewLanguages.FindAsync(crewMemberNumber, languageId);
            if (language == null)
            {
                return false;
            }

            _context.CabinCrewLanguages.Remove(language);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
