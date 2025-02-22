using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRProject.Application.DTOs.Response
{
    public record EmployeeResponse
    (
        Guid EmployeeId,
        string FullName,
        string Position
    );
}
