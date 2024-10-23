using AutoMapper;
using FinanceControl.Common.Consts;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Exceptions;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.DTOs.BaseDtos;
using FinanceControl.Domain.Models.DTOs.Reponses;
using FinanceControl.Domain.Models.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanceControl.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class ExpenseController : BaseCustomController
    {
        private readonly IExpenseWorker _expenseWorker;
        private readonly IMapper _mapper;
        private readonly ILogger<ExpenseController> _logger;


        public ExpenseController(IExpenseWorker expenseWorker, IMapper mapper , ILogger<ExpenseController> logger)
        {
            _expenseWorker = expenseWorker;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Response<ExpenseResponse>>> GetExpenseById([FromQuery] Guid id)
        {
            try
            {
                var response = await _expenseWorker.GetExpenseById(id);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }

        [HttpGet("List")]
        public async Task<ActionResult<CollectionResponse<ExpenseResponse>>> ListExpenseInDateRange([FromQuery] DateTime since, DateTime until)
        {
            var rangefilter = new DateRangeFilter { Since = since, Until = until };

            try
            {
                var response = await _expenseWorker.ListExpensesInRange(rangefilter);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        } 

        [HttpPost]
        public async Task<ActionResult<ExpenseResponse>> CreateExpense(ExpenseRequest expenseDto)
        {
            var expense = _mapper.Map<Expense>(expenseDto);

            try
            {
                var response = await _expenseWorker.CreateExpense(expense);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ExpenseResponse>> UpdateExpense(ExpenseRequest expenseDto)
        {
            var expense = _mapper.Map<Expense>(expenseDto);

            try
            {
                var response = await _expenseWorker.UpdateExpense(expense);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ExpenseResponse>> DeleteExpense(Guid id)
        {
            try
            {
                await _expenseWorker.DeleteExpense(id);
                return Ok();
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }
    }
}
