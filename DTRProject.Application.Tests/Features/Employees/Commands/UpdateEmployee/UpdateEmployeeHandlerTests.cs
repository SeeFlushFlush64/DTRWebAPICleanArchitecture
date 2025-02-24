using DTRProject.Application.DTOs;
using DTRProject.Application.DTOs.Request;
using DTRProject.Application.Features.Employees.Commands.UpdateEmployee;
using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace DTRProject.Application.Tests.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly UpdateEmployeeHandler _handler;

        public UpdateEmployeeHandlerTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _handler = new UpdateEmployeeHandler(_employeeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateExistingEmployee_WhenEmployeeExists()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var updateRequest = new UpdateEmployeeRequest("Jane", "Doe", "Senior Engineer");
            var command = new UpdateEmployeeCommand(employeeId, updateRequest);

            var existingEmployee = new Employee
            {
                EmployeeId = employeeId,
                FirstName = "John",
                LastName = "Doe",
                Position = "Software Engineer",
                DateHired = DateTime.UtcNow
            };

            var updatedEmployee = new Employee
            {
                EmployeeId = employeeId,
                FirstName = updateRequest.FirstName,
                LastName = updateRequest.LastName,
                Position = updateRequest.Position,
                DateHired = existingEmployee.DateHired
            };

            _employeeRepositoryMock
                .Setup(repo => repo.GetByIdAsync(employeeId))
                .ReturnsAsync(existingEmployee);

            _employeeRepositoryMock
                .Setup(repo => repo.UpdateAsync(It.IsAny<Employee>()))
                .ReturnsAsync(updatedEmployee);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new EmployeeDTO
            {
                EmployeeId = employeeId,
                FirstName = updateRequest.FirstName,
                LastName = updateRequest.LastName,
                Position = updateRequest.Position,
                DateHired = existingEmployee.DateHired
            });

            _employeeRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Employee>(e =>
                e.EmployeeId == employeeId &&
                e.FirstName == updateRequest.FirstName &&
                e.LastName == updateRequest.LastName &&
                e.Position == updateRequest.Position
            )), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var updateRequest = new UpdateEmployeeRequest("Jane", "Doe", "Senior Engineer");
            var command = new UpdateEmployeeCommand(employeeId, updateRequest);

            _employeeRepositoryMock
                .Setup(repo => repo.GetByIdAsync(employeeId))
                .ReturnsAsync((Employee)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeNull();
            _employeeRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Employee>()), Times.Never);
        }
    }
}
