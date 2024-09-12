using FinnanceControll.Common.Models;
using FinnanceControll.Domain.Models.Business;
using System.Collections.Immutable;

namespace FinnanceControll.Domain.Interfaces.Repositories
{
    public interface IExpenseRepository
    {
        void Create(Expense expense);

        void Update(Expense expense);

        void Delete(Guid Id);

        Expense Read(Guid Id);

        ImmutableList<Expense> List(DateRangeFilter rangeFilter);
    }
}