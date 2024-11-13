using ExpenseShare.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDues(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid user ID.");
            }

            try
            {
                var userDues = await _userService.GetDues(id);
                if (userDues == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(userDues);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
