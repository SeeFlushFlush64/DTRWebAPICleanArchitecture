using DTRProject.Domain.Interfaces;
using MediatR;
using System;

namespace DTRProject.Application.Features.TimeLogs.Commands.ClockOut
{
    /// <summary>
    /// Handles the clock-out operation for employees
    /// </summary>
    public class ClockOutHandler : IRequestHandler<ClockOutCommand, bool>
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public ClockOutHandler(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }


        /// <summary>
        /// Processes the clock-out command and updates the latest time log entry.
        /// </summary>
        /// <param name="request">The clock-out command containing employee ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>True if clock-out was successful; false if no active clock-in was found.</returns>
        public async Task<bool> Handle(ClockOutCommand request, CancellationToken cancellationToken)
        {
            var latestLog = await _timeLogRepository.GetLatestLogAsync(request.EmployeeId);
            if (latestLog == null || latestLog.ClockOutTime.HasValue)
                return false; // Prevent invalid clock-out
            var philippineTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            latestLog.ClockOutTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, philippineTimeZone);
            await _timeLogRepository.SaveChangesAsync();
            return true;
        }
    }
}
