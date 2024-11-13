using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Interfaces.Repositories;
using ExpenseShare.Application.Services;
using ExpenseShare.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetDues_ShouldReturnUserDto_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var balanceId = Guid.NewGuid();
            var groupId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                Name = "Rohan",
                Email = "rohan@mail.com",
                Password = "Rohan@123",
                Role = "Member",
                Balances = [new Balance { Id = balanceId, Dues = 29, GroupId = groupId, MemberId = userId, Group = new Group { Id = groupId, Name = "group"} }]
            };
            _userRepositoryMock.Setup(repo => repo.GetUserDetails(userId)).ReturnsAsync(user);

            var expectedUserDto = new UserDto
            {
                Id = userId,
                Name = "Rohan",
                GroupIds = [groupId],
                GroupNames = ["group"],
                GroupDuesIds = [balanceId],
                GroupDues = [29]
            };

            // Act
            var result = await _userService.GetDues(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUserDto.Id, result.Id);
            // Add other property assertions as needed
            _userRepositoryMock.Verify(repo => repo.GetUserDetails(userId), Times.Once);
        }
    }
}
