using ExpenseShare.Application.Dtos;
using ExpenseShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Convertors
{
    public static class ExpenseConvertor
    {
        public static ExpenseDetailsDto ConvertToDto(Expense expense)
        {
            if (expense == null)
                return null;

            return new ExpenseDetailsDto()
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                GroupId = expense.GroupId,
                GroupName = expense.Group.Name,
                //PaidByMemberId = expense.PaidByMemberId,
                PaidBy = expense.PaidBy,
                SplitAmongMemberIds = expense.ExpenseMembers.Select(x => x.Id).ToList(),
                SplitAmong = expense.ExpenseMembers.Select(x => x.Member.Name).ToList()
            };
        }

        public static Expense ConvertToEntity(ExpenseDto expenseDto)
        {
            if (expenseDto == null)
                return null;

            return new Expense()
            {
                Description = expenseDto.Description,
                Amount = expenseDto.Amount,
                GroupId = expenseDto.GroupId,
                // PaidByMemberId = new Guid(expenseDto.PaidByMemberId),
                Created = DateTime.Now,
                ExpenseMembers = expenseDto.SplitAmongMemberIds.Select(id => 
                    new ExpenseMember { 
                        MemberId = id, 
                        Created = DateTime.Now, 
                        AmountSplit = expenseDto.Amount / expenseDto.SplitAmongMemberIds.Count })
                    .ToList()
            };
        }
    }
}
