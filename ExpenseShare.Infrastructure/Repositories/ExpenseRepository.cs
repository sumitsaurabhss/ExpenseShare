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
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        private readonly ExpenseShareDbContext _dbContext;

        public ExpenseRepository(ExpenseShareDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Expense> GetExpenseDetails(Guid id)
        {
            var expense = await _dbContext.Expenses
                .Include(expense => expense.Group)
                //.Include(expense => expense.PaidByMemberId)
                .Include(expense => expense.ExpenseMembers)
                    .ThenInclude(expenseMember => expenseMember.Member)
                .FirstOrDefaultAsync(x => x.Id == id);

            return expense;
        }
    }
}
