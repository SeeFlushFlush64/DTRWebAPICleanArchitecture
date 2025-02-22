using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRProject.Application.DTOs.Request
{
    public record UpdateEmployeeRequest
    (
        string? FirstName,
        string? LastName,
        string? Position
    );
}
