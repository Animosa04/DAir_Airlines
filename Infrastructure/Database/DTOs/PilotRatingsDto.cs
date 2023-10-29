using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DTOs
{
    public class PilotRatingsDto
    {
        public int RatingID { get; set; }
        public string RatingPilotLicenseNumber { get; set; }
        public string RatedEmployeeNumber { get; set; }
        public int Rating { get; set; }
    }
}
