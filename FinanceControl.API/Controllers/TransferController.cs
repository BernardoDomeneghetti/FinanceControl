using FinanceControl.Common.Models;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class TransferController : CustomBaseController<TransferController>
    {
        private readonly ITransferWorker _TransferWorker;

        public TransferController(ITransferWorker TransferWorker, ILogger<TransferController> logger) : base(logger)
        {
            _TransferWorker = TransferWorker;
        }

        [HttpGet]
        public ActionResult<TransferResponse> GetTransferById([FromQuery] Guid id)
        {
            return WrappedOkExecute(_TransferWorker.GetTransferById, id);
        }

        [HttpGet("List")]
        public ActionResult<CollectionResponse<Transfer>> ListTransferInDateRange([FromQuery] DateTime since, DateTime until)
        {
            var rangefilter = new DateRangeFilter { Since = since, Until = until };

            return WrappedOkExecute(_TransferWorker.ListTransfersInRange, rangefilter);
        }

        [HttpPost]
        public ActionResult<TransferResponse> CreateTransfer(Transfer Transfer)
        {
            return WrappedCreatedExecute(_TransferWorker.CreateTransfer, Transfer);
        }

        [HttpPut]
        public ActionResult<TransferResponse> UpdateTransfer(Transfer Transfer)
        {
            return WrappedOkExecute(_TransferWorker.UpdateTransfer, Transfer);
        }

        [HttpDelete]
        public ActionResult<TransferResponse> DeleteTransfer(Guid id)
        {
            return WrappedDeletedExecute(_TransferWorker.DeleteTransfer, id);
        }
    }
}