using FinanceControl.Common.Models;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.DTOs.BaseDtos;
using FinanceControl.Domain.Models.DTOs.Reponses;

namespace FinanceControl.Domain.Interfaces.Workers
{
    public interface IReceiveWorker
    {
        Task<Response<ReceiveResponse>> CreateReceive(Receive receive);

        Task<Response<ReceiveResponse>> GetReceiveById(Guid id);

        Task<Response<ReceiveResponse>> UpdateReceive(Receive receive);

        Task DeleteReceive(Guid id);

        Task<CollectionResponse<ReceiveResponse>> ListReceivesInRange(DateRangeFilter rangefilter);
    }
}