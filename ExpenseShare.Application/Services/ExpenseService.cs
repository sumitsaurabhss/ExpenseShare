using ExpenseShare.Application.Convertors;
using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Exceptions;
using ExpenseShare.Application.Interfaces.Repositories;
using ExpenseShare.Application.Interfaces.Services;
using ExpenseShare.Domain.Entities;
using FluentValidation;

namespace ExpenseShare.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IValidator<ExpenseDto> _expenseValidator;
        private readonly IGroupRepository _groupRepository;
        private readonly IBalanceRepository _balanceRepository;
        private readonly IExpenseMemberRepository _expenseMemberRepository;
        private readonly IUserRepository _userRepository;

        public ExpenseService(
            IExpenseRepository expenseRepository,
            IValidator<ExpenseDto> expenseValidator,
            IGroupRepository groupRepository,
            IBalanceRepository balanceRepository,
            IExpenseMemberRepository expenseMemberRepository,
            IUserRepository userRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseValidator = expenseValidator;
            _groupRepository = groupRepository;
            _balanceRepository = balanceRepository;
            _expenseMemberRepository = expenseMemberRepository;
            _userRepository = userRepository;
        }

        public async Task<Boolean> AddExpense(ExpenseDto expenseDto)
        {
            var validationResult = _expenseValidator.Validate(expenseDto);
            if (!validationResult.IsValid)
                throw new InvalidDataException();

            var expense = ExpenseConvertor.ConvertToEntity(expenseDto);
            if (expense == null)
                throw new InvalidDataException();
            await HandleAmountSplit(expenseDto.SplitAmongMemberIds, expense.GroupId, expense.Amount);
            if (expenseDto.PaidByMemberId != String.Empty)
            {
                var user = await _userRepository.Get(new Guid(expenseDto.PaidByMemberId));
                expense.PaidBy = user.Name;
                await UpdateMemberBalance(new Guid(expenseDto.PaidByMemberId), expense);
            }

            await _expenseRepository.Add(expense);
            return true;
        }

        public async Task<ExpenseDetailsDto> GetExpenses(Guid id)
        {
            var expense = await _expenseRepository.GetExpenseDetails(id);
            return ExpenseConvertor.ConvertToDto(expense);
        }

        public async Task<Boolean> SettleExpense(Guid id, Guid paidByMemberId)
        {
            if (id == Guid.Empty || paidByMemberId == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var expense = await _expenseRepository.Get(id);
            if (expense == null)
                throw new NotFoundException();
            if (expense.PaidBy != null && expense.PaidBy != String.Empty)
                throw new InvalidOperationException(expense.PaidBy);

            var user = await _userRepository.Get(paidByMemberId);
            expense.PaidBy = user.Name;
            await UpdateMemberBalance(paidByMemberId, expense);

            await _expenseRepository.Update(expense);
            return true;
        }

        private async Task UpdateMemberBalance(Guid paidByMemberId, Expense expense)
        {
            var balances = await _balanceRepository.GetAll();
            var balance = balances.Where(b => b.MemberId == paidByMemberId && b.GroupId == expense.GroupId).FirstOrDefault();
            if (balance == null)
                throw new InvalidDataException();
            balance.Dues -= expense.Amount;
            await _balanceRepository.Update(balance);
        }

        public async Task HandleAmountSplit(ICollection<Guid> memberIds, Guid groupId, Decimal amount)
        {
            Decimal amountSplit = amount / memberIds.Count;
            var balances = await _balanceRepository.GetAll();
            foreach (var balance in balances.Where(b => memberIds.Contains(b.MemberId) && b.GroupId == groupId))
            {
                balance.Dues += amountSplit;
                await _balanceRepository.Update(balance);
            }
        }

        public async Task<Boolean> DeleteExpense(Guid id)
        {
            //var expenseDetails = await _expenseRepository.GetExpenseDetails(id);
            //if (expenseDetails == null)
            //    throw new InvalidDataException();
            //foreach (var em in expenseDetails.ExpenseMembers)
            //{
            //    try
            //    {
            //        var expenseMember = await _expenseMemberRepository.Get(em.Id);
            //        var result = _expenseMemberRepository.Delete(expenseMember);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new InvalidOperationException();
            //    }
            //}
            var expense = await _expenseRepository.Get(id);
            await _expenseRepository.Delete(expense);
            return true;
        }
    }
}
