﻿using DTRProject.Application.DTOs;
using DTRProject.Application.DTOs.Request;
using DTRProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRProject.Application.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeDTO ToEmployeeDTO(this Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                DateHired = employee.DateHired
            };
        }

        public static Employee ToEmployeeFromCreate(this CreateEmployeeRequest createDTO)
        {
            return new Employee
            {
                EmployeeId = Guid.NewGuid(), // Generate new Guid
                FirstName = createDTO.FirstName,
                LastName = createDTO.LastName,
                Position = createDTO.Position,
                DateHired = DateTime.UtcNow  // Set current date
            };
        }
        public static Employee ToEmployeeFromUpdate(this UpdateEmployeeRequest updateDTO, Employee existingEmployee)
        {
            return new Employee
            {
                EmployeeId = existingEmployee.EmployeeId, // Keep original ID
                FirstName = updateDTO.FirstName,
                LastName = updateDTO.LastName,
                Position = updateDTO.Position,
                DateHired = existingEmployee.DateHired // Keep original date hired
            };
        }

        public static void UpdateEmployeeFromDTO(this Employee existingEmployee, UpdateEmployeeRequest updateDTO)
        {
            existingEmployee.FirstName = updateDTO.FirstName;
            existingEmployee.LastName = updateDTO.LastName;
            existingEmployee.Position = updateDTO.Position;
            // Exclude updating EmployeeId and DateHired
        }
    }
}
