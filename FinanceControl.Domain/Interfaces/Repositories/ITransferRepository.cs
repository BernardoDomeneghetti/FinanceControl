using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using System.Collections.Immutable;

namespace FinanceControl.Domain.Interfaces.Repositories
{
    public interface ITransferRepository
    {
        void Create(Transfer transfer);

        void Update(Transfer transfer);

        void Delete(Guid Id);

        Transfer Read(Guid Id);

        ImmutableList<Transfer> List(DateRangeFilter rangeFilter);
    }
}