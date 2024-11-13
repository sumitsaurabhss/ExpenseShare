using ExpenseShare.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserDto> GetDues(Guid id);
    }
}
