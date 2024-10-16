

using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface IReceiveWorker
    {
        ReceiveResponse CreateReceive(Receive receive);

        ReceiveResponse GetReceiveById(Guid id);

        ReceiveResponse UpdateReceive(Receive receive);

        void DeleteReceive(Guid id);

        CollectionResponse<Receive> ListReceivesInRange(DateRangeFilter rangefilter);
    }
}