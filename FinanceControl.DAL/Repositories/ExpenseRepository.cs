

using System.Collections.Immutable;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.DAL.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        public async Task Create(Expense expense)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Expense expense)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Expense> Read(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ImmutableList<Expense>> List(DateRangeFilter rangeFilter)
        {
            throw new NotImplementedException();
        }
    }
}