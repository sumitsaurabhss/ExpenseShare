using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IGroupService groupService, ILogger<GroupController> logger)
        {
            _groupService = groupService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup([FromBody] GroupCreateDto groupDto)
        {
            if (groupDto == null)
            {
                return BadRequest("Group data is required.");
            }

            try
            {
                var result = await _groupService.AddGroup(groupDto);
                if (result)
                {
                    return Ok(new ResponseDto("Group added successfully."));
                }
                return BadRequest("Failed to add group.");
            }
            catch (InvalidDataException ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return BadRequest("Invalid group data.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupDetails(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid group ID.");
            }

            try
            {
                var groupDetails = await _groupService.GetGroupDetails(id);
                if (groupDetails == null)
                {
                    return NotFound("Group not found.");
                }
                return Ok(groupDetails);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            try
            {
                var groups = await _groupService.GetGroups();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("members/{id}")]
        public async Task<IActionResult> GetGroupMembers(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid group ID.");
            }

            try
            {
                var groupMembers = await _groupService.GetGroupMembers(id);
                if (groupMembers == null)
                {
                    return NotFound("Group not found.");
                }
                return Ok(groupMembers);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            try
            {
                var result = await _groupService.DeleteGroup(id);
                return Ok(result);
            }
            catch (InvalidDataException ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return NotFound("Group not found.");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Error deleting expenses.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
