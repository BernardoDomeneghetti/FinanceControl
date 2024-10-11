

using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface IReceiveWorker
    {
        ReceiveResponse CreateReceive(Receive Receive);

        ReceiveResponse GetReceiveById(Guid id);

        ReceiveResponse UpdateReceive(Receive Receive);

        void DeleteReceive(Guid id);

        CollectionResponse<Receive> ListReceivesInRange(DateRangeFilter rangefilter);
    }
}