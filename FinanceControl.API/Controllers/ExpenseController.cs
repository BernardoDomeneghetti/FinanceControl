using AutoMapper;
using FinanceControl.API.ControllerDtos;
using FinanceControl.Common.Consts;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Exceptions;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace FinanceControl.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class ExpenseController : ControllerBase
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
        public async Task<ActionResult<ExpenseResponse>> GetExpenseById([FromQuery] Guid id)
        {
            try
            {
                var response = await _expenseWorker.GetExpenseById(id);

                if (response.Payload == null)
                {
                    return NotFound(response);
                }

                return Ok(response);
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

        [HttpGet("List")]
        public async Task<ActionResult<CollectionResponse<ExpenseDto>>> ListExpenseInDateRange([FromQuery] DateTime since, DateTime until)
        {
            
            var rangefilter = new DateRangeFilter { Since = since, Until = until };

            try
            {
                var expenses = await _expenseWorker.ListExpensesInRange(rangefilter);

                var expensesDtos = _mapper.Map<List<ExpenseDto>>(expenses);
                
                var response = new CollectionResponse<ExpenseDto>
                {
                    Payload = expensesDtos
                };

                if (expensesDtos.IsNullOrEmpty())
                {
                    response.Message = ResponseMessages.ObjectNotFound404;
                    return NotFound(response);
                }

                response.Message = ResponseMessages.ObjectSuccessfullyRead200;
                return Ok(response);
            }
            catch(BadRequestException ex)
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

        [HttpPost]
        public async Task<ActionResult<ExpenseResponse>> CreateExpense(ExpenseDto expenseDto)
        {
            try
            {
                var expense = _mapper.Map<Expense>(expenseDto);
                var result = await _expenseWorker.CreateExpense(expense);
                return Ok(result);
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

        [HttpPut]
        public async Task<ActionResult<ExpenseResponse>> UpdateExpense(ExpenseDto expenseDto)
        {
            var expense = _mapper.Map<Expense>(expenseDto);
            try
            {
                var result = await _expenseWorker.UpdateExpense(expense);
                return Ok(result);
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
