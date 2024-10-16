

using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface ITransferWorker
    {
        TransferResponse CreateTransfer(Transfer transfer);

        TransferResponse GetTransferById(Guid id);

        TransferResponse UpdateTransfer(Transfer transfer);

        void DeleteTransfer(Guid id);

        CollectionResponse<Transfer> ListTransfersInRange(DateRangeFilter rangefilter);
    }
}