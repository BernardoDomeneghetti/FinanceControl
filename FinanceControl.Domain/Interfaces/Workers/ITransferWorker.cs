

using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface ITransferWorker
    {
        TransferResponse CreateTransfer(Transfer Transfer);

        TransferResponse GetTransferById(Guid id);

        TransferResponse UpdateTransfer(Transfer Transfer);

        void DeleteTransfer(Guid id);

        CollectionResponse<Transfer> ListTransfersInRange(DateRangeFilter rangefilter);
    }
}