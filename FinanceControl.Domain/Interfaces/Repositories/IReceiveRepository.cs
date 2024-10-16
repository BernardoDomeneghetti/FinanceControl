using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using System.Collections.Immutable;

namespace FinanceControl.Domain.Interfaces.Repositories
{
    public interface IReceiveRepository
    {
        Task Create(Receive receive);

        Task Update(Receive receive);

        Task Delete(Guid Id);

        Task<Receive> Read(Guid Id);

        Task<ImmutableList<Receive>> List(DateRangeFilter rangeFilter);
    }
}