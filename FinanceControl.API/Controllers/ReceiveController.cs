using FinanceControl.API.ControllerDtos;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class ReceiveController : CustomBaseController<ReceiveController>
    {
        private readonly IReceiveWorker _ReceiveWorker;

        public ReceiveController(IReceiveWorker ReceiveWorker, ILogger<ReceiveController> logger) : base(logger)
        {
            _ReceiveWorker = ReceiveWorker;
        }

        [HttpGet]
        public ActionResult<ReceiveResponse> GetReceiveById([FromQuery] Guid id)
        {
            return WrappedOkExecute(_ReceiveWorker.GetReceiveById, id);
        }

        [HttpGet("List")]
        public ActionResult<CollectionResponse<Receive>> ListReceiveInDateRange([FromQuery] DateTime since, DateTime until)
        {
            var rangefilter = new DateRangeFilter { Since = since, Until = until };

            return WrappedOkExecute(_ReceiveWorker.ListReceivesInRange, rangefilter);
        }

        [HttpPost]
        public ActionResult<ReceiveResponse> CreateReceive(ReceiveDto receiveDto)
        {
            var receive = receiveDto.Adapt<Receive>();
            return WrappedCreatedExecute(_ReceiveWorker.CreateReceive, receive);
        }

        [HttpPut]
        public ActionResult<ReceiveResponse> UpdateReceive(ReceiveDto receiveDto)
        {
            var receive = receiveDto.Adapt<Receive>();
            return WrappedOkExecute(_ReceiveWorker.UpdateReceive, receive);
        }

        [HttpDelete]
        public ActionResult<ReceiveResponse> DeleteReceive(Guid id)
        {
            return WrappedDeletedExecute(_ReceiveWorker.DeleteReceive, id);
        }
    }
}