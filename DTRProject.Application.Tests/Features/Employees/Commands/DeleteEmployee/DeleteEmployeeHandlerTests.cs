using DTRProject.Application.Features.Employees.Commands.DeleteEmployee;
using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace DTRProject.Application.Tests.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly DeleteEmployeeHandler _handler;

        public DeleteEmployeeHandlerTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _handler = new DeleteEmployeeHandler(_employeeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenEmployeeExistsAndIsDeleted()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var existingEmployee = new Employee { EmployeeId = employeeId, FirstName = "John", LastName = "Doe" };

            _employeeRepositoryMock
                .Setup(repo => repo.GetByIdAsync(employeeId))
                .ReturnsAsync(existingEmployee);

            _employeeRepositoryMock
                .Setup(repo => repo.DeleteAsync(existingEmployee))
                .ReturnsAsync(true);

            var command = new DeleteEmployeeCommand(employeeId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
            _employeeRepositoryMock.Verify(repo => repo.DeleteAsync(existingEmployee), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var employeeId = Guid.NewGuid();

            _employeeRepositoryMock
                .Setup(repo => repo.GetByIdAsync(employeeId))
                .ReturnsAsync((Employee)null);

            var command = new DeleteEmployeeCommand(employeeId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeFalse();
            _employeeRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<Employee>()), Times.Never);
        }
    }
}
