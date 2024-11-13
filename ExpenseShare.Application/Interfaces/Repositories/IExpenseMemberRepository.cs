﻿using ExpenseShare.Application.Services;
using ExpenseShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Interfaces.Repositories
{
    public interface IExpenseMemberRepository : IGenericRepository<ExpenseMember>
    {
        public Task<Boolean> DeleteExpenseMember(ExpenseMember expenseMember);
    }
}