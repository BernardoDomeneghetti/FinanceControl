

using System.Collections.Immutable;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface IReceiveWorker
    {
        Task<ReceiveResponse> CreateReceive(Receive receive);

        Task<ReceiveResponse> GetReceiveById(Guid id);

        Task<ReceiveResponse> UpdateReceive(Receive receive);

        Task DeleteReceive(Guid id);

        Task<ImmutableList<Receive>> ListReceivesInRange(DateRangeFilter rangefilter);
    }
}