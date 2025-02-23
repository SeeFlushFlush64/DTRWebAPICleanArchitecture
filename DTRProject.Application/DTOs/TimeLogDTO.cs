using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRProject.Application.DTOs
{
    public class TimeLogDTO
    {
        public Guid TimeLogId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime? ClockOutTime { get; set; }

        // Optional: Include Employee Name only
        public string? EmployeeName { get; set; }
    }
}
