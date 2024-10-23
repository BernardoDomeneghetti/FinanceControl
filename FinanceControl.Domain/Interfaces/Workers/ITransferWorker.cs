

using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.DTOs.BaseDtos;
using FinanceControl.Domain.Models.DTOs.Reponses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface ITransferWorker
    {
        Task<Response<TransferResponse>> CreateTransfer(Transfer transfer);

        Task<Response<TransferResponse>> GetTransferById(Guid id);

        Task<Response<TransferResponse>> UpdateTransfer(Transfer transfer);

        Task DeleteTransfer(Guid id);

        Task<CollectionResponse<TransferResponse>> ListTransfersInRange(DateRangeFilter rangefilter);
    }
}