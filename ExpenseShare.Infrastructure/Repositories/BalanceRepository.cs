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
    public class BalanceRepository : GenericRepository<Balance>, IBalanceRepository
    {
        private readonly ExpenseShareDbContext _dbContext;

        public BalanceRepository(ExpenseShareDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
