using FinnanceControll.Models.Common;
using FinnanceControll.Models.Domain;
using System.Collections.Immutable;

namespace FinnanceControll.Interfaces.Repositories
{
    public interface IExpenseRepository
    {
        void Create(Expense expense);

        void Update(Expense expense);

        void Delete(Guid Id);

        void Read(Guid Id);

        ImmutableList<Expense> List(DateRangeFilter rangeFilter);
    }
}