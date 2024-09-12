

using System.Collections.Immutable;
using FinnanceControll.Common.Models;
using FinnanceControll.Domain.Interfaces.Repositories;
using FinnanceControll.Domain.Models.Business;

namespace FinnanceControll.DAL.Repositories
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