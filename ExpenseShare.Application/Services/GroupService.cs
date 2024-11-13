using ExpenseShare.Application.Convertors;
using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Interfaces.Repositories;
using ExpenseShare.Application.Interfaces.Services;
using ExpenseShare.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IValidator<GroupCreateDto> _groupValidator;
        private readonly IBalanceRepository _balanceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IExpenseService _expenseService;

        public GroupService(
            IGroupRepository groupRepository,
            IValidator<GroupCreateDto> groupValidator,
            IBalanceRepository balanceRepository,
            IUserRepository userRepository,
            IExpenseService expenseService)
        {
            _groupRepository = groupRepository;
            _groupValidator = groupValidator;
            _balanceRepository = balanceRepository;
            _userRepository = userRepository;
            _expenseService = expenseService;
        }

        public async Task<Boolean> AddGroup(GroupCreateDto groupDto)
        {
            var validationResult = _groupValidator.Validate(groupDto);
            if (!validationResult.IsValid)
                throw new InvalidDataException();

            var group = GroupConvertor.ConvertToEntity(groupDto);
            if (group == null)
                throw new InvalidDataException();

            var users = await _userRepository.GetAll();
            var matchedIds = users
                .Where(user => groupDto.MemberEmails.Contains(user.Email))
                .Select(user => user.Id)
                .ToList();
            group.Balances = matchedIds.Select(id => new Balance { MemberId = id, Created = DateTime.Now }).ToList();

            await _groupRepository.Add(group);
            return true;
        }

        public async Task<IReadOnlyCollection<GroupDto>> GetGroups()
        {
            var groups = await _groupRepository.GetAll();
            return GroupConvertor.ConvertToGroupDto(groups);
        }

        public async Task<GroupDetailsDto> GetGroupDetails(Guid id)
        {
            var group = await _groupRepository.GetGroupDetails(id);
            return GroupConvertor.ConvertToDto(group);
        }

        public async Task<GroupMembersDto> GetGroupMembers(Guid id)
        {
            //var balances = await _balanceRepository.GetAll();
            //var memberIds = balances
            //    .Where(balance => balance.GroupId == id)
            //    .Select(balance => balance.MemberId)
            //    .ToList();
            //var users = await _userRepository.GetAll();

            var group = await _groupRepository.GetGroupDetails(id);
            return GroupConvertor.ConvertToGroupMembersDto(group);
        }

        public async Task<Boolean> DeleteGroup(Guid id)
        {
            //var groupDetails = await _groupRepository.GetGroupDetails(id);
            //if (groupDetails == null)
            //    throw new InvalidDataException();
            //foreach (var expense in groupDetails.Expenses)
            //{
            //    try
            //    {
            //        var result = _expenseService.DeleteExpense(expense.Id);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new InvalidOperationException();
            //    }
            //}
            var group = await _groupRepository.Get(id);
            await _groupRepository.Delete(group);
            return true;
        }
    }
}
