

using System.Collections.Immutable;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.DAL.Repositories
{
    public class ReceiveRepository : IReceiveRepository
    {
        public void Create(Receive Receive)
        {
            throw new NotImplementedException();
        }

        public void Update(Receive Receive)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Receive Read(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ImmutableList<Receive> List(DateRangeFilter rangeFilter)
        {
            throw new NotImplementedException();
        }
    }
}