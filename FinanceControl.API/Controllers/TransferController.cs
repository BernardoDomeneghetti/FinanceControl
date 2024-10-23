using AutoMapper;
using FinanceControl.Common.Consts;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Exceptions;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.DTOs.BaseDtos;
using FinanceControl.Domain.Models.DTOs.Reponses;
using FinanceControl.Domain.Models.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanceControl.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class TransferController : BaseCustomController
    {
        private readonly ITransferWorker _TransferWorker;
        private readonly IMapper _mapper;
        private readonly ILogger<TransferController> _logger;


        public TransferController(ITransferWorker TransferWorker, IMapper mapper , ILogger<TransferController> logger)
        {
            _TransferWorker = TransferWorker;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Response<TransferResponse>>> GetTransferById([FromQuery] Guid id)
        {
            try
            {
                var response = await _TransferWorker.GetTransferById(id);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }

        [HttpGet("List")]
        public async Task<ActionResult<CollectionResponse<TransferResponse>>> ListTransferInDateRange([FromQuery] DateTime since, DateTime until)
        {
            var rangefilter = new DateRangeFilter { Since = since, Until = until };

            try
            {
                var response = await _TransferWorker.ListTransfersInRange(rangefilter);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        } 

        [HttpPost]
        public async Task<ActionResult<TransferResponse>> CreateTransfer(TransferRequest transferDto)
        {
            var Transfer = _mapper.Map<Transfer>(transferDto);

            try
            {
                var response = await _TransferWorker.CreateTransfer(Transfer);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<TransferResponse>> UpdateTransfer(TransferRequest transferDto)
        {
            var Transfer = _mapper.Map<Transfer>(transferDto);

            try
            {
                var response = await _TransferWorker.UpdateTransfer(Transfer);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<TransferResponse>> DeleteTransfer(Guid id)
        {
            try
            {
                await _TransferWorker.DeleteTransfer(id);
                return Ok();
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }
    }
}
