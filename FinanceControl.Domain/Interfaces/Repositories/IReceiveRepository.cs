using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using System.Collections.Immutable;

namespace FinanceControl.Domain.Interfaces.Repositories
{
    public interface IReceiveRepository
    {
        void Create(Receive receive);

        void Update(Receive receive);

        void Delete(Guid Id);

        Receive Read(Guid Id);

        ImmutableList<Receive> List(DateRangeFilter rangeFilter);
    }
}