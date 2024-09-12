

using FinnanceControll.Common.Models;
using FinnanceControll.Domain.Models.Business;
using FinnanceControll.Domain.Models.Responses;

namespace FinnanceControll.Domain.Interfaces.Workers
{
    public interface IExpenseWorker
    {
        ExpenseResponse CreateExpense(Expense expense);

        ExpenseResponse GetExpenseById(Guid id);

        ExpenseResponse UpdateExpense(Expense expense);

        void DeleteExpense(Guid id);

        CollectionResponse<Expense> ListExpensesInRange(DateRangeFilter rangefilter);
    }
}