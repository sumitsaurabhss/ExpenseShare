using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Exceptions;
using ExpenseShare.Application.Interfaces.Repositories;
using ExpenseShare.Domain.Entities;
using ExpenseShare.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ExpenseShareDbContext _dbContext;

        public UserRepository(ExpenseShareDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Signin(LoginRequestDto loginDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync<User>(x => x.Email == loginDto.Email && x.Password == loginDto.Password);
            return user ?? throw new NotFoundException();
        }


        public async Task<User> GetUserDetails(Guid id)
        {
            var user = await _dbContext.Users
                .Include(user => user.Balances)
                    .ThenInclude(balance => balance.Group)
                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

    }
}