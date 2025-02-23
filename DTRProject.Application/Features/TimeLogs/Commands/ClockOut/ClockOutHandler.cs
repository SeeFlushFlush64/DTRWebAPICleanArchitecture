using DTRProject.Domain.Interfaces;
using MediatR;
using System;

namespace DTRProject.Application.Features.TimeLogs.Commands.ClockOut
{
    public class ClockOutHandler : IRequestHandler<ClockOutCommand, bool>
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public ClockOutHandler(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }

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
