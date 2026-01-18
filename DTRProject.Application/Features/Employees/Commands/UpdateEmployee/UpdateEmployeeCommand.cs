using DTRProject.Application.DTOs;
using DTRProject.Application.DTOs.Request;
using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Commands.UpdateEmployee
{
    /// <summary>
    /// Command to update an existing employee's information.
    /// </summary>
    /// <param name="EmployeeId">The unique identifier of the employee to update.</param>
    /// <param name="EmployeeDTO">The updated employee details.</param>
    public record UpdateEmployeeCommand(Guid EmployeeId, UpdateEmployeeRequest EmployeeDTO) : IRequest<EmployeeDTO>;
}
