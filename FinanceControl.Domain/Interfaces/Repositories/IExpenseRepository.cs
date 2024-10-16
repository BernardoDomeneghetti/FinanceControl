using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using System.Collections.Immutable;

namespace FinanceControl.Domain.Interfaces.Repositories
{
    public interface IExpenseRepository
    {
        Task Create(Expense expense);

        Task Update(Expense expense);

        Task Delete(Guid Id);

        Task<Expense> Read(Guid Id);

        Task<ImmutableList<Expense>> List(DateRangeFilter rangeFilter);
    }
}