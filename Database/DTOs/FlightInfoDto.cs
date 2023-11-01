namespace Database.DTOs
{
    public class FlightInfoDto
    {
        public string StateName { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }
    }
}
