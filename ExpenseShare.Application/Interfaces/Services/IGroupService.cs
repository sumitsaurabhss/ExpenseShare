using ExpenseShare.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Interfaces.Services
{
    public interface IGroupService
    {
        public Task<GroupDetailsDto> GetGroupDetails(Guid id);
        public Task<IReadOnlyCollection<GroupDto>> GetGroups();
        public Task<Boolean> AddGroup(GroupCreateDto groupDto);
        public Task<GroupMembersDto> GetGroupMembers(Guid id);
        public Task<Boolean> DeleteGroup(Guid id);
    }
}
