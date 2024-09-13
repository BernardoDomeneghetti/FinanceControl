

using System.Collections.Immutable;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.DAL.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        public void Create(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void Update(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Expense Read(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ImmutableList<Expense> List(DateRangeFilter rangeFilter)
        {
            throw new NotImplementedException();
        }
    }
}