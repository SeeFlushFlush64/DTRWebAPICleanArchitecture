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

            var newLog = new TimeLog
            {
                TimeLogId = Guid.NewGuid(),
                EmployeeId = request.EmployeeId,
                Date = DateTime.UtcNow.Date,
                ClockInTime = DateTime.UtcNow
            };

            await _timeLogRepository.AddTimeLogAsync(newLog);
            await _timeLogRepository.SaveChangesAsync();
            return true;
        }
    }
}
