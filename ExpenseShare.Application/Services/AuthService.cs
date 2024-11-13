using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Interfaces.Repositories;
using ExpenseShare.Application.Interfaces.Services;

namespace ExpenseShare.Application.Services
{
    public class AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) : IAuthService
    {
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await userRepository.Signin(loginRequestDto);

            if (user != null)
            {
                //if user was found , Generate JWT Token
                var token = jwtTokenGenerator.GenerateToken(user);

                LoginResponseDto loginResponseDto = new()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Token = token,
                    IsAdmin = user.Role.Equals("Admin", StringComparison.CurrentCultureIgnoreCase),
                    Expiry = 60
                };

                return loginResponseDto;
            }

            return new LoginResponseDto();
        }
    }
}