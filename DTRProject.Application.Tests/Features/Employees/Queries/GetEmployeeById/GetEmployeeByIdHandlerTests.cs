using DTRProject.Application.Features.Employees.Queries.GetEmployeeById;
using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace DTRProject.Application.Tests.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly GetEmployeeByIdQueryHandler _handler;

        public GetEmployeeByIdQueryHandlerTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _handler = new GetEmployeeByIdQueryHandler(_employeeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var expectedEmployee = new Employee
            {
                EmployeeId = employeeId,
                FirstName = "Jane",
                LastName = "Doe",
                Position = "Software Engineer",
                DateHired = DateTime.UtcNow
            };

            _employeeRepositoryMock
                .Setup(repo => repo.GetByIdAsync(employeeId))
                .ReturnsAsync(expectedEmployee);

            var query = new GetEmployeeByIdQuery(employeeId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedEmployee);
            _employeeRepositoryMock.Verify(repo => repo.GetByIdAsync(employeeId), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var employeeId = Guid.NewGuid();

            _employeeRepositoryMock
                .Setup(repo => repo.GetByIdAsync(employeeId))
                .ReturnsAsync((Employee)null);

            var query = new GetEmployeeByIdQuery(employeeId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();
            _employeeRepositoryMock.Verify(repo => repo.GetByIdAsync(employeeId), Times.Once);
        }
    }
}
