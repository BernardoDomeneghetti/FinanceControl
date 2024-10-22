using AutoMapper;
using FinanceControl.API.ControllerDtos;
using FinanceControl.Common.Consts;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Exceptions;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace FinanceControl.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class ReceiveController : ControllerBase
    {
        private readonly IReceiveWorker _ReceiveWorker;
        private readonly IMapper _mapper;
        private readonly ILogger<ReceiveController> _logger;

        public ReceiveController(IReceiveWorker ReceiveWorker, IMapper mapper, ILogger<ReceiveController> logger)
        {
            _ReceiveWorker = ReceiveWorker;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ReceiveResponse>> GetReceiveById([FromQuery] Guid id)
        {
            try
            {       
                var response = await _ReceiveWorker.GetReceiveById(id);
                if (response.Payload == null)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch(BadRequestException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseMessages.InternalServerError500
                );
            }
        }

        [HttpGet("List")]
        public async Task<ActionResult<CollectionResponse<ReceiveDto>>> ListReceiveInDateRange([FromQuery] DateTime since, DateTime until)
        {
            try
            {
                var rangefilter = new DateRangeFilter { Since = since, Until = until };
                var receives = await _ReceiveWorker.ListReceivesInRange(rangefilter);

                var receiveDtos = _mapper.Map<List<ReceiveDto>>(receives);
                
                var response = new CollectionResponse<ReceiveDto>
                {
                    Payload = receiveDtos
                };

                if (receiveDtos.IsNullOrEmpty())
                {
                    response.Message = ResponseMessages.ObjectNotFound404;
                    return NotFound(response);
                }

                response.Message = ResponseMessages.ObjectSuccessfullyRead200;
                return Ok(response);
            }
            catch(BadRequestException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseMessages.InternalServerError500
                );
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReceiveResponse>> CreateReceive(ReceiveDto receiveDto)
        {
            try
            {
                var receive = _mapper.Map<Receive>(receiveDto);
                var response = await _ReceiveWorker.CreateReceive(receive);
                return Ok(response);
            }
            catch(BadRequestException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseMessages.InternalServerError500
                );
            }

        }

        [HttpPut]
        public async Task<ActionResult<ReceiveResponse>> UpdateReceive(ReceiveDto receiveDto)
        {
            try
            {
                var receive = _mapper.Map<Receive>(receiveDto);
                var response = await _ReceiveWorker.UpdateReceive(receive);
                return Ok(response);
            }
            catch(BadRequestException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseMessages.InternalServerError500
                );
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ReceiveResponse>> DeleteReceive(Guid id)
        {
            try
            {
                await _ReceiveWorker.DeleteReceive(id);
                return Ok(ResponseMessages.ObjectSussessfullyDeleted204);
            }
            catch(BadRequestException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ResponseMessages.InternalServerError500
                );
            }
            
        }
    }
}