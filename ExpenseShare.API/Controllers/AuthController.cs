using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Interfaces.Services;
using ExpenseShare.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (loginRequest == null)
                return BadRequest("Empty Request");

            var loginResponse = await authService.Login(loginRequest);
            if (loginResponse.Token == String.Empty)
            {
                return BadRequest();
            }
            return loginResponse;
        }
    }
}
