using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Commands.ClockIn
{
    public class ClockInHandler : IRequestHandler<ClockInCommand, bool>
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public ClockInHandler(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }

        public async Task<bool> Handle(ClockInCommand request, CancellationToken cancellationToken)
        {
            var latestLog = await _timeLogRepository.GetLatestLogAsync(request.EmployeeId);
            if (latestLog != null && latestLog.ClockOutTime == null)
                return false; // Prevent multiple clock-ins


            var philippineTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            var philippineTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, philippineTimeZone);

            var newLog = new TimeLog
            {
                TimeLogId = Guid.NewGuid(),
                EmployeeId = request.EmployeeId,
                ClockInTime = philippineTime // Store full date-time
            };


            await _timeLogRepository.AddTimeLogAsync(newLog);
            await _timeLogRepository.SaveChangesAsync();
            return true;
        }
    }
}
