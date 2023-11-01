using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DTOs
{
    public class CabinCrewMemberDto
    {
        public string CabinCrewMemberNumber { get; set; }
        public string CrewMemberEmployeeNumber { get; set; }
        public string Position { get; set; }
    }
}
