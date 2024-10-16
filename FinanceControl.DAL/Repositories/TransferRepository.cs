

using System.Collections.Immutable;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.DAL.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        public async Task Create(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Transfer> Read(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ImmutableList<Transfer>> List(DateRangeFilter rangeFilter)
        {
            throw new NotImplementedException();
        }
    }
}