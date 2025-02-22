using DTRProject.Application.DTOs;
using DTRProject.Application.DTOs.Request;
using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Commands.UpdateEmployee
{
    public record UpdateEmployeeCommand(Guid EmployeeId, UpdateEmployeeRequest EmployeeDTO) : IRequest<EmployeeDTO>;
}
