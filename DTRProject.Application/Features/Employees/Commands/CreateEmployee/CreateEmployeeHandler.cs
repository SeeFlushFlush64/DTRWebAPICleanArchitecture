using DTRProject.Application.DTOs;
using DTRProject.Application.Mappers;
using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using MediatR;

namespace DTRProject.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeHandler(IEmployeeRepository employeeRepository) : IRequestHandler<CreateEmployeeCommand, EmployeeDTO>
    {
        public async Task<EmployeeDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Map DTO to Entity
            var employeeEntity = request.EmployeeDTO.ToEmployeeFromCreate();

            // Ensure default time logs are assigned (if required)
            if (employeeEntity.TimeLogs is null)
            {
                employeeEntity.TimeLogs = new List<TimeLog>
                {
                    new TimeLog { ClockInTime = DateTime.UtcNow, EmployeeId = employeeEntity.EmployeeId }
                };
            }

            // Call the repository, which now also assigns TimeLogs
            var createdEmployee = await employeeRepository.AddAsync(employeeEntity);

            // Map back to DTO before returning response
            return createdEmployee.ToEmployeeDTO();
        }
    }
}
