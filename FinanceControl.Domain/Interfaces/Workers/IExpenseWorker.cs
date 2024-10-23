

using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.DTOs.BaseDtos;
using FinanceControl.Domain.Models.DTOs.Reponses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface IExpenseWorker
    {
        Task<Response<ExpenseResponse>> CreateExpense(Expense expense);

        Task<Response<ExpenseResponse>> GetExpenseById(Guid id);

        Task<Response<ExpenseResponse>> UpdateExpense(Expense expense);

        Task DeleteExpense(Guid id);

        Task<CollectionResponse<ExpenseResponse>> ListExpensesInRange(DateRangeFilter rangefilter);
    }
}