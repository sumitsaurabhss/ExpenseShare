using ExpenseShare.Application.Convertors;
using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Interfaces.Repositories;
using ExpenseShare.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetDues(Guid id)
        {
            var user = await _userRepository.GetUserDetails(id);
            return UserConvertor.ConvertToDto(user);
        }
    }
}
