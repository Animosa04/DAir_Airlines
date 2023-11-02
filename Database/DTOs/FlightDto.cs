using System.ComponentModel.DataAnnotations;

namespace Database.DTOs
{
    public class FlightDto
    {
        public string FlightCode { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        [RegularExpression(@"^\d{8} \d{4}$", ErrorMessage = "Date must be in 'DDMMYYYY HHMM' format.")]
        public string ScheduledDepartureTime { get; set; }
        [RegularExpression(@"^\d{8} \d{4}$", ErrorMessage = "Date must be in 'DDMMYYYY HHMM' format.")]
        public string ScheduledArrivalTime { get; set; }
        public string AircraftRegistrationNumber { get; set; }
        public string CaptainLicenseNumber { get; set; }
        public string FirstOfficerLicenseNumber { get; set; }
        public int CurrentStateID { get; set; }
    }
}
