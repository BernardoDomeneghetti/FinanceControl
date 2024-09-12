using FinnanceControll.Common.Models;
using FinnanceControll.Domain.Interfaces.Workers;
using FinnanceControll.Domain.Models.Business;
using FinnanceControll.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FinnanceControll.API.Controllers
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
        public ActionResult<CollectionResponse<Expense>> ListExpenseInDateRange([FromQuery] DateTime since, DateTime unli)
        {
            var rangefilter = new DateRangeFilter { Since = since, Until = unli };

            return WrappedOkExecute(_expenseWorker.ListExpensesInRange, rangefilter);
        }

        [HttpPost]
        public ActionResult<ExpenseResponse> CreateExpense(Expense expense)
        {
            return WrappedCreatedExecute(_expenseWorker.CreateExpense, expense);
        }

        [HttpPut]
        public ActionResult<ExpenseResponse> UpdateExpense(Expense expense)
        {
            return WrappedOkExecute(_expenseWorker.UpdateExpense, expense);
        }

        [HttpDelete]
        public ActionResult<ExpenseResponse> DeleteExpense(Guid id)
        {
            return WrappedDeletedExecute(_expenseWorker.DeleteExpense, id);
        }
    }
}