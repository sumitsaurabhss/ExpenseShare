using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Interfaces.Repositories;
using ExpenseShare.Application.Interfaces.Services;
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
    public class AuthServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IJwtTokenGenerator> _mockJwtTokenGenerator;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockJwtTokenGenerator = new Mock<IJwtTokenGenerator>();
            _authService = new AuthService(_mockUserRepository.Object, _mockJwtTokenGenerator.Object);
        }

        [Fact]
        public async Task Login_ValidUser_ReturnsLoginResponseDto()
        {
            // Arrange
            var loginRequestDto = new LoginRequestDto
            {
                Email = "testuser@mail.com",
                Password = "Test@123"
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Test User",
                Email = "testuser@mail.com",
                Role = "Member"
            };

            var token = "TestJWTToken";

            _mockUserRepository.Setup(repo => repo.Signin(loginRequestDto)).ReturnsAsync(user);
            _mockJwtTokenGenerator.Setup(generator => generator.GenerateToken(user)).Returns(token);

            // Act
            var result = await _authService.Login(loginRequestDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(token, result.Token);
            Assert.False(result.IsAdmin);
            Assert.Equal(60, result.Expiry);
        }

        [Fact]
        public async Task Login_InvalidUser_ReturnsEmptyLoginResponseDto()
        {
            // Arrange
            var loginRequestDto = new LoginRequestDto
            {
                Email = "invaliduser@mail.com",
                Password = "WrongPassword"
            };

            _mockUserRepository.Setup(repo => repo.Signin(loginRequestDto)).ReturnsAsync(value: null);

            // Act
            var result = await _authService.Login(loginRequestDto);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Name);
            Assert.Null(result.Token);
            Assert.False(result.IsAdmin);
            Assert.Equal(0, result.Expiry);
        }

        [Fact]
        public async Task Login_UserIsAdmin_ReturnsAdminLoginResponseDto()
        {
            // Arrange
            var loginRequestDto = new LoginRequestDto
            {
                Email = "adminuser@mail.com",
                Password = "Admin@123"
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Admin User",
                Email = "adminuser@mail.com",
                Role = "Admin"
            };

            var token = "GeneratedAdminJWTToken";

            _mockUserRepository.Setup(repo => repo.Signin(loginRequestDto)).ReturnsAsync(user);
            _mockJwtTokenGenerator.Setup(generator => generator.GenerateToken(user)).Returns(token);

            // Act
            var result = await _authService.Login(loginRequestDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(token, result.Token);
            Assert.True(result.IsAdmin);
            Assert.Equal(60, result.Expiry);
        }
    }
}
