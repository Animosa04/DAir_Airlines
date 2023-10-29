using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DTOs
{
    public class AircraftModelDto
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int PassengerCapacity { get; set; }
    }
}
    