using ExpenseShare.Application.Dtos;
using ExpenseShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Signin(LoginRequestDto loginDto);
        public Task<User> GetUserDetails(Guid id);
    }
}