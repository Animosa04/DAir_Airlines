﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DTOs
{
    public class DailyTripDto
    {
        public int TripID { get; set; }
        public string EmployeeNumber { get; set; }
        public string BaseAirport { get; set; }
    }
}
