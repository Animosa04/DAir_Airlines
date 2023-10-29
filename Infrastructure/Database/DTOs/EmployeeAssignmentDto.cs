using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DTOs
{
    public class EmployeeAssignmentDto
    {
        public int AssignmentID { get; set; }
        public int TripID { get; set; }
        public string FlightCode { get; set; }
    }
}
