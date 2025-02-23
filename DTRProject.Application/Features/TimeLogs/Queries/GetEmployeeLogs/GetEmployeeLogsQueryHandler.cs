using DTRProject.Application.DTOs;
using DTRProject.Application.Mappers;
using DTRProject.Domain.Interfaces;
using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Queries.GetEmployeeLogs
{
    public class GetEmployeeLogsQueryHandler : IRequestHandler<GetEmployeeLogsQuery, List<TimeLogDTO>>
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public GetEmployeeLogsQueryHandler(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }

        public async Task<List<TimeLogDTO>> Handle(GetEmployeeLogsQuery request, CancellationToken cancellationToken)
        {
            var timeLogs = await _timeLogRepository.GetLogsByEmployeeAsync(request.EmployeeId);
            return timeLogs.ToTimeLogDTOList(); // Use the mapper to convert to DTOs
        }
    }
}
