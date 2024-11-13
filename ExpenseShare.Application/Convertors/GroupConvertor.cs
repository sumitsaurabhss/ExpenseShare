using ExpenseShare.Application.Dtos;
using ExpenseShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Convertors
{
    public static class GroupConvertor
    {
        public static GroupDetailsDto ConvertToDto(Group group)
        {
            if (group == null)
                return null;

            return new GroupDetailsDto()
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                MemberIds = group.Balances.Select(b => b.MemberId).ToList(),
                MemberNames = group.Balances.Select(b => b.Member.Name).ToList(),
                MemberDuesIds = group.Balances.Select(b => b.Id).ToList(),
                MemberDues = group.Balances.Select(b => b.Dues).ToList(),
                ExpenseIds = group.Expenses.Select(e => e.Id).ToList(),
                ExpenseDescriptions = group.Expenses.Select(e => e.Description).ToList(),
                ExpenseAmounts = group.Expenses.Select(e => e.Amount).ToList()
            };
        }

        public static GroupMembersDto ConvertToGroupMembersDto(Group group)
        {
            if (group == null)
                return null;

            return new GroupMembersDto()
            {
                GroupId = group.Id,
                MemberIds = group.Balances.Select(b => b.MemberId).Distinct().ToList(),
                MemberNames = group.Balances.Select(b => b.Member.Name).Distinct().ToList()
            };
        }

        public static Group ConvertToEntity(GroupCreateDto groupDto)
        {
            if (groupDto == null)
                return null;

            return new Group()
            {
                Name = groupDto.Name,
                Description = groupDto.Description,
                Created = DateTime.Now,
                // Balances = groupDto.MemberIds.Select(id => new Balance { MemberId = id, Created = DateTime.Now }).ToList()
            };
        }

        public static GroupDto ConvertToGroupDto(Group group)
        {
            if (group == null)
                return null;

            return new GroupDto()
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description
            };
        }

        public static List<GroupDto> ConvertToGroupDto(IEnumerable<Group> groups)
        {
            if (groups == null)
                return null;

            return groups.Select(group => ConvertToGroupDto(group)).ToList();
        }
    }
}
