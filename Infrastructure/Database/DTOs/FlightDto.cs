namespace Infrastructure.Database.DTOs
{
    public class FlightDto
    {
        public string FlightCode { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }
        public string AircraftRegistrationNumber { get; set; }
        public string CaptainLicenseNumber { get; set; }
        public string FirstOfficerLicenseNumber { get; set; }
        public int CurrentStateID { get; set; }
    }
}
