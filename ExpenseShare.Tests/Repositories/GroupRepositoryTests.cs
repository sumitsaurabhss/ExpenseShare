using ExpenseShare.Domain.Entities;
using ExpenseShare.Infrastructure.DbContexts;
using ExpenseShare.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Tests.Repositories
{
    public class GroupRepositoryTests
    {
        //Dependencies
        private readonly Mock<ExpenseShareDbContext> dbContext;

        //SUT
        private readonly GroupRepository groupRepository;

        public GroupRepositoryTests()
        {
            // Dependencies
            dbContext = new Mock<ExpenseShareDbContext>();

            //SUT
            groupRepository = new GroupRepository(dbContext.Object);
        }

        [Fact]
        public async Task Add_ValidGroup_CanCreateGroup()
        {
            // Arrange
            var group = new Group()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Description = "Test Group",
                Created = DateTime.Now
            };

            dbContext.Setup(x => x.Add(It.IsAny<Group>()));

            // Act
            var result = await groupRepository.Add(group);

            // Assert
            Assert.NotNull(result);
        }
    }
}
