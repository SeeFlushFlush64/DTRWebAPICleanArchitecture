using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRProject.Domain.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; } // Unique company-assigned ID
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime DateHired { get; set; }
        public bool IsDeleted { get; set; } = false; // Soft delete flag
    }
}
