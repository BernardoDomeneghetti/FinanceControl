

using System.Collections.Immutable;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.DAL.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        public void Create(Transfer Transfer)
        {
            throw new NotImplementedException();
        }

        public void Update(Transfer Transfer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Transfer Read(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ImmutableList<Transfer> List(DateRangeFilter rangeFilter)
        {
            throw new NotImplementedException();
        }
    }
}