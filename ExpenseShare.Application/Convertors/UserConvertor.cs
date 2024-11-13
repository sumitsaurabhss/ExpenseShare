using ExpenseShare.Application.Dtos;
using ExpenseShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Convertors
{
    public static class UserConvertor
    {
        public static UserDto ConvertToDto(User user)
        {
            if (user == null)
                return null;

            return new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                GroupIds = user.Balances.Select(b => b.GroupId).Distinct().ToList(),
                GroupNames = user.Balances.Select(b => b.Group.Name).ToList(),
                GroupDuesIds = user.Balances.Select(b => b.Id).ToList(),
                GroupDues = user.Balances.Select(b => b.Dues).ToList()
            };
        }
    }
}
