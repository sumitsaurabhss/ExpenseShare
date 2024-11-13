using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Exceptions;
using ExpenseShare.Infrastructure.Repositories;
using ExpenseShare.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseShare.Infrastructure.DbContexts;

namespace ExpenseShare.Application.Interfaces.Repositories
{
    public class UserRepositoryTests
    {
        // private readonly MockExpenseShareDbContext _mockDbContext;
        //private readonly Mock<ExpenseShareDbContext> _mockDbContext;
        //private readonly UserRepository _userRepository;

        //public UserRepositoryTests()
        //{
        //    _userRepository = new UserRepository(_mockDbContext.Object);
        //}

        //[Fact]
        //public async Task Signin_ValidCredentials_ReturnsUser()
        //{
        //    // Arrange
        //    var loginDto = new LoginRequestDto
        //    {
        //        Email = "testuser@mail.com",
        //        Password = "Test@123"
        //    };

        //    var user = new User
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Test User",
        //        Email = "testuser@mail.com",
        //        Password = "Test@123",
        //        Role = "Tester",
        //        Created = DateTime.Now,
        //    };

        //    _mockDbContext.Setup(x => x.FirstOr)
        //    user = await _userRepository.Add(user);

        //    // Act
        //    var result = await _userRepository.Signin(loginDto);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(user.Email, result.Email);
        //    Assert.Equal(user.Password, result.Password);
        //}

        //[Fact]
        //public async Task Signin_InvalidCredentials_ThrowsNotFoundException()
        //{
        //    // Arrange
        //    var loginRequestDto = new LoginRequestDto
        //    {
        //        Email = "invaliduser@mail.com",
        //        Password = "WrongPassword"
        //    };

        //    // Act & Assert
        //    await Assert.ThrowsAsync<NotFoundException>(() => _userRepository.Signin(loginRequestDto));
        //}
    }
}
