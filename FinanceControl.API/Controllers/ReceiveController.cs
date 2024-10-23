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
    public class ReceiveController : BaseCustomController
    {
        private readonly IReceiveWorker _ReceiveWorker;
        private readonly IMapper _mapper;
        private readonly ILogger<ReceiveController> _logger;


        public ReceiveController(IReceiveWorker ReceiveWorker, IMapper mapper , ILogger<ReceiveController> logger)
        {
            _ReceiveWorker = ReceiveWorker;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Response<ReceiveResponse>>> GetReceiveById([FromQuery] Guid id)
        {
            try
            {
                var response = await _ReceiveWorker.GetReceiveById(id);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }

        [HttpGet("List")]
        public async Task<ActionResult<CollectionResponse<ReceiveResponse>>> ListReceiveInDateRange([FromQuery] DateTime since, DateTime until)
        {
            var rangefilter = new DateRangeFilter { Since = since, Until = until };

            try
            {
                var response = await _ReceiveWorker.ListReceivesInRange(rangefilter);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        } 

        [HttpPost]
        public async Task<ActionResult<ReceiveResponse>> CreateReceive(ReceiveRequest receiveDto)
        {
            var Receive = _mapper.Map<Receive>(receiveDto);

            try
            {
                var response = await _ReceiveWorker.CreateReceive(Receive);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ReceiveResponse>> UpdateReceive(ReceiveRequest receiveDto)
        {
            var Receive = _mapper.Map<Receive>(receiveDto);

            try
            {
                var response = await _ReceiveWorker.UpdateReceive(Receive);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return Problem(ResponseMessages.InternalServerError500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ReceiveResponse>> DeleteReceive(Guid id)
        {
            try
            {
                await _ReceiveWorker.DeleteReceive(id);
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
