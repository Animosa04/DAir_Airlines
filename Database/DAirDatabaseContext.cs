using Database.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DAirDatabaseContext : DbContext
    {
        public DAirDatabaseContext(DbContextOptions<DAirDatabaseContext> options) : base(options)
        {
        }

        public DbSet<AircraftModelDto> AircraftModels { get; set; }
        public DbSet<AircraftDto> Aircrafts { get; set; }
        public DbSet<EmployeeDto> Employees { get; set; }
        public DbSet<CabinCrewMemberDto> CabinCrewMembers { get; set; }
        public DbSet<LanguageDto> Languages { get; set; }
        public DbSet<CabinCrewLanguagesDto> CabinCrewLanguages { get; set; }
        public DbSet<PilotDto> Pilots { get; set; }
        public DbSet<PilotCertificationsDto> PilotCertifications { get; set; }
        public DbSet<PilotRatingsDto> PilotRatings { get; set; }
        public DbSet<FlightStateDto> FlightStates { get; set; }
        public DbSet<FlightDto> Flights { get; set; }
        public DbSet<DailyTripDto> DailyTrips { get; set; }
        public DbSet<EmployeeAssignmentDto> EmployeeAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting up composite keys
            modelBuilder.Entity<AircraftModelDto>()
                .HasKey(am => am.Model);

            modelBuilder.Entity<AircraftDto>()
                .HasKey(a => a.RegistrationNumber);

            modelBuilder.Entity<EmployeeDto>()
                .HasKey(e => e.EmployeeNumber);

            modelBuilder.Entity<CabinCrewMemberDto>()
                .HasKey(cc => cc.CabinCrewMemberNumber);

            modelBuilder.Entity<LanguageDto>()
                .HasKey(l => l.LanguageID);

            modelBuilder.Entity<PilotDto>()
                .HasKey(p => p.PilotLicenseNumber);

            modelBuilder.Entity<PilotRatingsDto>()
                .HasKey(pr => pr.RatingID);

            modelBuilder.Entity<FlightStateDto>()
                .HasKey(fs => fs.StateID);

            modelBuilder.Entity<FlightDto>()
                .HasKey(f => f.FlightCode);

            modelBuilder.Entity<DailyTripDto>()
                .HasKey(dt => dt.TripID);

            modelBuilder.Entity<EmployeeAssignmentDto>()
                .HasKey(ea => ea.AssignmentID);

            modelBuilder.Entity<CabinCrewLanguagesDto>()
                .HasKey(cl => new { cl.CabinCrewMemberNumber, cl.LanguageID });

            modelBuilder.Entity<PilotCertificationsDto>()
                .HasKey(pc => new { pc.PilotLicenseNumber, pc.AircraftModel });

            // Relationships

            // Aircraft to AircraftModel
            modelBuilder.Entity<AircraftDto>()
                .HasOne(typeof(AircraftModelDto))
                .WithMany()
                .HasForeignKey("AircraftModel");

            // CabinCrewMember to Employee
            modelBuilder.Entity<CabinCrewMemberDto>()
                .HasOne(typeof(EmployeeDto))
                .WithMany()
                .HasForeignKey("CrewMemberEmployeeNumber");

            // CabinCrewLanguages to CabinCrewMember & Languages
            modelBuilder.Entity<CabinCrewLanguagesDto>()
                .HasOne(typeof(CabinCrewMemberDto))
                .WithMany()
                .HasForeignKey("CabinCrewMemberNumber");
            modelBuilder.Entity<CabinCrewLanguagesDto>()
                .HasOne(typeof(LanguageDto))
                .WithMany()
                .HasForeignKey("LanguageID");

            // Pilot to Employee
            modelBuilder.Entity<PilotDto>()
                .HasOne(typeof(EmployeeDto))
                .WithMany()
                .HasForeignKey("PilotEmployeeNumber");

            // PilotCertifications to Pilot & AircraftModel
            modelBuilder.Entity<PilotCertificationsDto>()
                .HasOne(typeof(PilotDto))
                .WithMany()
                .HasForeignKey("PilotLicenseNumber");
            modelBuilder.Entity<PilotCertificationsDto>()
                .HasOne(typeof(AircraftModelDto))
                .WithMany()
                .HasForeignKey("AircraftModel");

            // PilotRatings to Pilot & Employee
            modelBuilder.Entity<PilotRatingsDto>()
                .HasOne(typeof(PilotDto))
                .WithMany()
                .HasForeignKey("RatingPilotLicenseNumber")
                .OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<PilotRatingsDto>()
                .HasOne(typeof(EmployeeDto))
                .WithMany()
                .HasForeignKey("RatedEmployeeNumber")
                .OnDelete(DeleteBehavior.Restrict); ;

            // Flight to Aircraft, Pilot (Captain & FirstOfficer), FlightState
            modelBuilder.Entity<FlightDto>()
                .HasOne(typeof(AircraftDto))
                .WithMany()
                .HasForeignKey("AircraftRegistrationNumber");
            modelBuilder.Entity<FlightDto>()
                .HasOne(typeof(PilotDto))
                .WithMany()
                .HasForeignKey("CaptainLicenseNumber")
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FlightDto>()
                .HasOne(typeof(PilotDto))
                .WithMany()
                .HasForeignKey("FirstOfficerLicenseNumber")
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FlightDto>()
                .HasOne(typeof(FlightStateDto))
                .WithMany()
                .HasForeignKey("CurrentStateID");

            // DailyTrip to Employee
            modelBuilder.Entity<DailyTripDto>()
                .HasOne(typeof(EmployeeDto))
                .WithMany()
                .HasForeignKey("EmployeeNumber");

            // EmployeeAssignment to DailyTrip & Flight
            modelBuilder.Entity<EmployeeAssignmentDto>()
                .HasOne(typeof(DailyTripDto))
                .WithMany()
                .HasForeignKey("TripID");
            modelBuilder.Entity<EmployeeAssignmentDto>()
                .HasOne(typeof(FlightDto))
                .WithMany()
                .HasForeignKey("FlightCode");
        }
    }
}
