

using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;

namespace FinanceControl.Domain.Interfaces.Workers
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