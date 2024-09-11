using System.Collections.Immutable;
using FinnanceControll.Interfaces.Repositories;
using FinnanceControll.Models.Common;
using FinnanceControll.Models.Domain;

namespace FinnanceControll.Repositories
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