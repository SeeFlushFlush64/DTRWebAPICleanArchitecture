using DTRProject.Application.DTOs;
using DTRProject.Application.DTOs.Request;
using DTRProject.Application.Features.Employees.Commands.CreateEmployee;
using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DTRProject.Application.Tests.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly CreateEmployeeHandler _handler;

        public CreateEmployeeHandlerTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _handler = new CreateEmployeeHandler(_employeeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCallRepositoryAddAsync_WithMappedEmployee()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var employeeRequest = new CreateEmployeeRequest("John", "Doe", "Software Engineer");
            var command = new CreateEmployeeCommand(employeeRequest);

            var createdEmployee = new Employee
            {
                EmployeeId = employeeId,
                FirstName = employeeRequest.FirstName,
                LastName = employeeRequest.LastName,
                Position = employeeRequest.Position,
                TimeLogs = new List<TimeLog>() // Assuming your domain entity has this
            };

            _employeeRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Employee>()))
                .ReturnsAsync(createdEmployee);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Employee>(
                e => e.FirstName == employeeRequest.FirstName
                  && e.LastName == employeeRequest.LastName
                  && e.Position == employeeRequest.Position
            )), Times.Once);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new EmployeeDTO
            {
                EmployeeId = employeeId,
                FirstName = employeeRequest.FirstName,
                LastName = employeeRequest.LastName,
                Position = employeeRequest.Position
            });
        }
    }
}
