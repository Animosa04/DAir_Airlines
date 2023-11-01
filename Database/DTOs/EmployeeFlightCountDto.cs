using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DTOs
{
    public class EmployeeFlightCountDto
    {
        public string EmployeeName { get; set; }
        public string BaseAirport { get; set; }
        public int NumberOfFlights { get; set; }
    }
}
