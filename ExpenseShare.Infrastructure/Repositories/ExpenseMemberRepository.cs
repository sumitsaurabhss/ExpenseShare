using ExpenseShare.Application.Interfaces.Repositories;
using ExpenseShare.Domain.Entities;
using ExpenseShare.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Infrastructure.Repositories
{
    public class ExpenseMemberRepository : GenericRepository<ExpenseMember>, IExpenseMemberRepository
    {
        private readonly ExpenseShareDbContext _dbContext;

        public ExpenseMemberRepository(ExpenseShareDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Boolean> DeleteExpenseMember(ExpenseMember expenseMember)
        {
            _dbContext.ExpenseMembers.Remove(expenseMember);
            return true;
        }
    }
}
