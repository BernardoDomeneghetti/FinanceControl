using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using System.Collections.Immutable;

namespace FinanceControl.Domain.Interfaces.Repositories
{
    public interface ITransferRepository
    {
        Task Create(Transfer transfer);

        Task Update(Transfer transfer);

        Task Delete(Guid Id);

        Task<Transfer> Read(Guid Id);

        Task<ImmutableList<Transfer>> List(DateRangeFilter rangeFilter);
    }
}