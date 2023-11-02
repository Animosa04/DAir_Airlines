using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DTOs
{
    public class PilotConflictsDto
    {
        public int ConflictID { get; set; }
        public string PilotLicenseNumber { get; set; }
        public string ConflicsWithPilot { get; set; }
    }
}
