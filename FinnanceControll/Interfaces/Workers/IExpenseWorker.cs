using FinnanceControll.Models.Common;
using FinnanceControll.Models.Domain;
using FinnanceControll.Models.Responses;

namespace FinnanceControll.Interfaces.Workers
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