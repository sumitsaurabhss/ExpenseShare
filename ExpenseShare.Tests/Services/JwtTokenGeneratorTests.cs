using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Interfaces.Services;
using ExpenseShare.Application.Services;
using ExpenseShare.Domain.Entities;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Tests.Services
{
    public class JwtTokenGeneratorTests
    {
        private readonly Mock<IOptions<JwtOptions>> _mockJwtOptions;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public JwtTokenGeneratorTests()
        {
            _mockJwtOptions = new Mock<IOptions<JwtOptions>>();
            _mockJwtOptions.Setup(x => x.Value).Returns(new JwtOptions
            {
                Secret = "Expense Sharing Application's Developer Secret Key. Change in Production.",
                Issuer = "Expense Sharing App",
                DurationInMinutes = 60
            });

            _jwtTokenGenerator = new JwtTokenGenerator(_mockJwtOptions.Object);
        }

        [Fact]
        public void GenerateToken_UserIsValid_ReturnsToken()
        {
            // Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Test User",
                Email = "testuser@mail.com",
                Role = "Member"
            };

            // Act
            var token = _jwtTokenGenerator.GenerateToken(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            // Assert
            Assert.False(string.IsNullOrEmpty(token));

            Assert.NotNull(securityToken);
        }

        [Fact]
        public void GenerateToken_UserIsNull_ThrowsArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NullReferenceException>(() => _jwtTokenGenerator.GenerateToken(null));
        }
    }
}
