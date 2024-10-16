
// using AutoMapper;
// using FinanceControl.API.ControllerDtos;
// using FinanceControl.Common.Models;
// using FinanceControl.Domain.Interfaces.Workers;
// using FinanceControl.Domain.Models.Business;
// using FinanceControl.Domain.Models.Responses;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// namespace FinanceControl.API.Controllers
// {
//     [ApiController]
//     [Route("/api/v1/[Controller]")]
//     public class TransferController : CustomBaseController<TransferController>
//     {
//         private readonly ITransferWorker _TransferWorker;
//         private readonly IMapper _mapper;
//         public TransferController(ITransferWorker TransferWorker, ILogger<TransferController> logger, IMapper mapper) : base(logger)
//         {
//             _TransferWorker = TransferWorker;
//             _mapper = mapper;
//         }

//         [HttpGet]
//         public ActionResult<TransferResponse> GetTransferById([FromQuery] Guid id)
//         {
//             return WrappedOkExecute(_TransferWorker.GetTransferById, id);
//         }

//         [HttpGet("List")]
//         public ActionResult<CollectionResponse<Transfer>> ListTransferInDateRange([FromQuery] DateTime since, DateTime until)
//         {
//             var rangefilter = new DateRangeFilter { Since = since, Until = until };

//             return WrappedOkExecute(_TransferWorker.ListTransfersInRange, rangefilter);
//         }

//         [HttpPost]
//         public ActionResult<TransferResponse> CreateTransfer(TransferDto transferDto)
//         {
//             var transfer = _mapper.Map<Transfer>(transferDto);
//             return WrappedCreateExecute(_TransferWorker.CreateTransfer, transfer);
//         }

//         [HttpPut]
//         public ActionResult<TransferResponse> UpdateTransfer(TransferDto transferDto)
//         {
//             var transfer = _mapper.Map<Transfer>(transferDto);
//             return WrappedOkExecute(_TransferWorker.UpdateTransfer, transfer);
//         }

//         [HttpDelete]
//         public ActionResult<TransferResponse> DeleteTransfer(Guid id)
//         {
//             return WrappedDeletedExecute(_TransferWorker.DeleteTransfer, id);
//         }
//     }
// }