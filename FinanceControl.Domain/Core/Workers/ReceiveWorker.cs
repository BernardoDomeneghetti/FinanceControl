using System.Collections.Immutable;
using AutoMapper;
using FinanceControl.Common.Consts;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Core.Validators;
using FinanceControl.Domain.Helpers;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.DTOs;
using FinanceControl.Domain.Models.DTOs.BaseDtos;
using FinanceControl.Domain.Models.DTOs.Reponses;

namespace FinanceControl.Domain.Core.Workers
{
    public class ReceiveWorker : IReceiveWorker
    {
        private readonly IReceiveRepository _ReceiveRepository;
        private readonly ReceiveValidator _ReceiveValidator;
        private readonly RangeFilterValidation _rangeFilterValidator;
        private readonly IMapper _mapper;

        public ReceiveWorker(IReceiveRepository ReceiveRepository, IMapper mapper)
        {
            _ReceiveRepository = ReceiveRepository;
            _ReceiveValidator = new ReceiveValidator();
            _rangeFilterValidator = new RangeFilterValidation();
            _mapper = mapper;
        }

        public async Task<Response<ReceiveResponse>> CreateReceive(Receive receive)
        {
            var validation = _ReceiveValidator.Validate(receive);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.ToImmutableList();
                return new Response<ReceiveResponse>
                {
                    Code = ResponseHttpCode.BadRequest,
                    Message = ValidationMessageFactory.GetValidationMessage(errors)
                };
            }

            receive.ExternalId = Guid.NewGuid();

                await _ReceiveRepository.Create(receive);

                var result = new Response<ReceiveResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<ReceiveResponse>(receive)
                };

                return result;
            
        }

        public async Task DeleteReceive(Guid id)
        {
            await _ReceiveRepository.Delete(id);
        }

        public async Task<Response<ReceiveResponse>> GetReceiveById(Guid id)
        {
            try
            {
                var Receive = await _ReceiveRepository.Read(id);

                var result = new Response<ReceiveResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<ReceiveResponse>(Receive)
                };

                return result;
            }
            catch (KeyNotFoundException)
            {
                return new Response<ReceiveResponse>
                {
                    Code = ResponseHttpCode.NotFound,
                    Message = ResponseMessages.ObjectNotFound404
                };
            }
        }

        public async Task<CollectionResponse<ReceiveResponse>> ListReceivesInRange(DateRangeFilter rangefilter)
        {
            try
            {
                var Receives = await _ReceiveRepository.List(rangefilter);

                var result = new CollectionResponse<ReceiveResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<List<ReceiveResponse>>(Receives)
                };

                return result;
            }
            catch (KeyNotFoundException)
            {
                return new CollectionResponse<ReceiveResponse>
                {
                    Code = ResponseHttpCode.NotFound,
                    Message = ResponseMessages.ObjectNotFound404
                };
            }
        }

        public async Task<Response<ReceiveResponse>> UpdateReceive(Receive receive)
        {
            var validation = _ReceiveValidator.Validate(receive);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.ToImmutableList();
                return new Response<ReceiveResponse>
                {
                    Code = ResponseHttpCode.BadRequest,
                    Message = ValidationMessageFactory.GetValidationMessage(errors)
                };
            }
            
            try
            {
                await _ReceiveRepository.Update(receive);

                var result = new Response<ReceiveResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<ReceiveResponse>(receive)
                };

                return result;
            }
            catch (KeyNotFoundException)
            {
                return new Response<ReceiveResponse>
                {
                    Code = ResponseHttpCode.NotFound,
                    Message = ResponseMessages.ObjectNotFound404
                };
            }
        }
    }
}