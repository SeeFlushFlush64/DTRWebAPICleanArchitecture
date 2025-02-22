using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRProject.Application.DTOs
{
    public class EmployeeDTO
    {
        public Guid EmployeeId { get; set; }  // Expose EmployeeId for retrieval
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime DateHired { get; set; }  // Include only if necessary
    }
}
