using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DTOs
{
    public class AircraftDto
    {
        public string AircraftModel { get; set; }

        public string RegistrationNumber { get; set; }

        public int YearOfManufacture { get; set; }
    }
}
