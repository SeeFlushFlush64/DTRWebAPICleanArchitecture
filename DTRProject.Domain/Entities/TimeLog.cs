namespace DTRProject.Domain.Entities
{
    public class TimeLog
    {
        public Guid TimeLogId { get; set; } // Primary Key
        public Guid? EmployeeId { get; set; } // Foreign Key to Employee
        public DateTime ClockInTime { get; set; } // Store full date-time
        public DateTime? ClockOutTime { get; set; } // Nullable for pending logouts

        // Navigation property
        public Employee Employee { get; set; } = null!;

    }
}
