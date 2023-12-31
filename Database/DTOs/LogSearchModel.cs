﻿namespace Database.DTOs
{
    public class LogSearchModel
    {
        public string Username { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string OperationType { get; set; } // POST, PUT, DELETE
    }

}
