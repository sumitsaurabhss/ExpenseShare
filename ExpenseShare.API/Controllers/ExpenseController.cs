using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Exceptions;
using ExpenseShare.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly ILogger<ExpenseController> _logger;

        public ExpenseController(IExpenseService expenseService, ILogger<ExpenseController> logger)
        {
            _expenseService = expenseService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] ExpenseDto expenseDto)
        {
            if (expenseDto == null)
            {
                return BadRequest("Expense data is required.");
            }

            try
            {
                var result = await _expenseService.AddExpense(expenseDto);
                if (result)
                {
                    return Ok(new ResponseDto("Expense added successfully."));
                }
                return BadRequest("Failed to add expense.");
            }
            catch (InvalidDataException ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return BadRequest("Invalid expense data.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseDetails(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid expense ID.");
            }

            try
            {
                var expenseDetails = await _expenseService.GetExpenses(id);
                if (expenseDetails == null)
                {
                    return NotFound("Expense not found.");
                }
                return Ok(expenseDetails);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("settle")]
        public async Task<IActionResult> SettleExpense([FromBody] SettleDto settleDto)
        {
            if (settleDto.Id == Guid.Empty || settleDto.PaidByMemberId == Guid.Empty)
            {
                return BadRequest("Invalid ID(s).");
            }

            try
            {
                var result = await _expenseService.SettleExpense(settleDto.Id, settleDto.PaidByMemberId);
                if (result)
                {
                    return Ok(new ResponseDto("Expense settled successfully."));
                }
                return BadRequest("Failed to settle expense.");
            }
            catch (NotFoundException ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return NotFound("Expense not found.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\n\n\n\n\n\n\n\n\n\nError: {ex.Message}\n\n\n\n\n\n\n\n\n\n");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
