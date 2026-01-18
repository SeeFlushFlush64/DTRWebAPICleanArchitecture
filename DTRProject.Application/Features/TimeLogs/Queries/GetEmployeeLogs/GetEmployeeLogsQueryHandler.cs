using DTRProject.Application.DTOs;
using DTRProject.Application.Mappers;
using DTRProject.Domain.Interfaces;
using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Queries.GetEmployeeLogs
{
    /// <summary>
    /// Handles retrieval of time log records for an employee.
    /// </summary>
    public class GetEmployeeLogsQueryHandler : IRequestHandler<GetEmployeeLogsQuery, List<TimeLogDTO>>
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public GetEmployeeLogsQueryHandler(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }


        /// <summary>
        /// Retrieves all time logs for the specified employee.
        /// </summary>
        /// <param name="request">The clock-out command containing employee ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of time log data transfer objects for the employee.</returns>
        public async Task<List<TimeLogDTO>> Handle(GetEmployeeLogsQuery request, CancellationToken cancellationToken)
        {
            var timeLogs = await _timeLogRepository.GetLogsByEmployeeAsync(request.EmployeeId);
            return timeLogs.ToTimeLogDTOList(); // Use the mapper to convert to DTOs
        }
    }
}
