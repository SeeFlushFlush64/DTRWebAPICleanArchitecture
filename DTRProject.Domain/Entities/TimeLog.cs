using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace DTRProject.Domain.Entities
{
    public class TimeLog
    {
        public Guid TimeLogId { get; set; } // Primary Key
        public Guid EmployeeId { get; set; } // Foreign Key to Employee
        public DateTime Date { get; set; } // The date of the log

        [JsonConverter(typeof(IsoDateTimeConverter))] // Formats JSON output
        public DateTime ClockInTime { get; set; } // Stored in UTC

        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? ClockOutTime { get; set; } // Nullable, stored in UTC

        // Converts UTC to Philippine Standard Time (PHT) when displaying
        public DateTime GetClockInTimePHT()
        {
            TimeZoneInfo phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(ClockInTime, phTimeZone);
        }

        public DateTime? GetClockOutTimePHT()
        {
            if (ClockOutTime.HasValue)
            {
                TimeZoneInfo phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(ClockOutTime.Value, phTimeZone);
            }
            return null;
        }
    }
}
