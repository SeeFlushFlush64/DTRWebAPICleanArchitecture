using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRProject.Application.DTOs.Request
{
    public record DeleteEmployeeRequest
    (
        Guid EmployeeId,
        string? FirstName,
        string? LastName,
        string? Position
    );
}
