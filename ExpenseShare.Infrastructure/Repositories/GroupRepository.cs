using ExpenseShare.Application.Interfaces.Repositories;
using ExpenseShare.Domain.Entities;
using ExpenseShare.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Infrastructure.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        private readonly ExpenseShareDbContext _dbContext;

        public GroupRepository(ExpenseShareDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Group> GetGroupDetails(Guid id)
        {
            var group = await _dbContext.Groups
                .Include(group => group.Balances)
                    .ThenInclude(balance => balance.Member)
                .Include(group => group.Expenses)
                .FirstOrDefaultAsync(x => x.Id == id);

            return group;
        }

    }
}
