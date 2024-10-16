

using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface ITransferWorker
    {
        Task<TransferResponse> CreateTransfer(Transfer transfer);

        Task<TransferResponse> GetTransferById(Guid id);

        Task<TransferResponse> UpdateTransfer(Transfer transfer);

        Task DeleteTransfer(Guid id);

        Task<CollectionResponse<Transfer>> ListTransfersInRange(DateRangeFilter rangefilter);
    }
}