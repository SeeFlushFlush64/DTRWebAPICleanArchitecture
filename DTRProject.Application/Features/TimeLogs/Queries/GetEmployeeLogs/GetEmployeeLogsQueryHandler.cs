using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Queries.GetEmployeeLogs
{
    public class GetEmployeeLogsQueryHandler : IRequestHandler<GetEmployeeLogsQuery, List<TimeLog>>
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public GetEmployeeLogsQueryHandler(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }

        public async Task<List<TimeLog>> Handle(GetEmployeeLogsQuery request, CancellationToken cancellationToken)
        {
            return await _timeLogRepository.GetLogsByEmployeeAsync(request.EmployeeId);
        }
    }
}
