

using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface IExpenseWorker
    {
        Task<ExpenseResponse> CreateExpense(Expense expense);

        Task<ExpenseResponse> GetExpenseById(Guid id);

        Task<ExpenseResponse> UpdateExpense(Expense expense);

        Task DeleteExpense(Guid id);

        Task<CollectionResponse<Expense>> ListExpensesInRange(DateRangeFilter rangefilter);
    }
}