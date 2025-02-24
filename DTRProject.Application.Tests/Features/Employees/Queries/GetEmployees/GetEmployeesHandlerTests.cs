using DTRProject.Application.Features.Employees.Queries.GetEmployees;
using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace DTRProject.Application.Tests.Features.Employees.Queries.GetEmployees
{
    public class GetEmployeesQueryHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly GetEmployeesQueryHandler _handler;

        public GetEmployeesQueryHandlerTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _handler = new GetEmployeesQueryHandler(_employeeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfEmployees_WhenEmployeesExist()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith", Position = "Developer", DateHired = DateTime.UtcNow },
                new Employee { EmployeeId = Guid.NewGuid(), FirstName = "Bob", LastName = "Johnson", Position = "Manager", DateHired = DateTime.UtcNow }
            };

            _employeeRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(employees);

            var query = new GetEmployeesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(employees);
            _employeeRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoEmployeesExist()
        {
            // Arrange
            _employeeRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Employee>()); // Return an empty list

            var query = new GetEmployeesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull(); // Should return an empty list, not null
            result.Should().BeEmpty();
            _employeeRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }
    }
}
