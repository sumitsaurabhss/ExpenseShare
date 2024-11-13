using ExpenseShare.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Interfaces.Services
{
    public interface IExpenseService
    {
        public Task<ExpenseDetailsDto> GetExpenses(Guid id);
        public Task<Boolean> AddExpense(ExpenseDto expenseDto);
        public Task<Boolean> SettleExpense(Guid id, Guid paidByMemberId);
        public Task<Boolean> DeleteExpense(Guid id);
    }
}
