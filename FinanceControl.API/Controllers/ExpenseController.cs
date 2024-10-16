using FinanceControl.API.ControllerDtos;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class ExpenseController : CustomBaseController<ExpenseController>
    {
        private readonly IExpenseWorker _expenseWorker;

        public ExpenseController(IExpenseWorker expenseWorker, ILogger<ExpenseController> logger) : base(logger)
        {
            _expenseWorker = expenseWorker;
        }

        [HttpGet]
        public ActionResult<ExpenseResponse> GetExpenseById([FromQuery] Guid id)
        {
            return WrappedOkExecute(_expenseWorker.GetExpenseById, id);
        }

        [HttpGet("List")]
        public ActionResult<CollectionResponse<Expense>> ListExpenseInDateRange([FromQuery] DateTime since, DateTime until)
        {
            var rangefilter = new DateRangeFilter { Since = since, Until = until };

            return WrappedOkExecute(_expenseWorker.ListExpensesInRange, rangefilter);
        }

        [HttpPost]
        public ActionResult<ExpenseResponse> CreateExpense(ExpenseDto expenseDto)
        {
            var expense = expenseDto.Adapt<Expense>();
            return WrappedCreatedExecute(_expenseWorker.CreateExpense, expense);
        }

        [HttpPut]
        public ActionResult<ExpenseResponse> UpdateExpense(ExpenseDto expenseDto)
        {
            var expense = expenseDto.Adapt<Expense>();
            return WrappedOkExecute(_expenseWorker.UpdateExpense, expense);
        }

        [HttpDelete]
        public ActionResult<ExpenseResponse> DeleteExpense(Guid id)
        {
            return WrappedDeletedExecute(_expenseWorker.DeleteExpense, id);
        }
    }
}