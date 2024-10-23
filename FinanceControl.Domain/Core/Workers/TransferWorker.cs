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
    public class TransferWorker : ITransferWorker
    {
        private readonly ITransferRepository _TransferRepository;
        private readonly TransferValidator _TransferValidator;
        private readonly RangeFilterValidation _rangeFilterValidator;
        private readonly IMapper _mapper;

        public TransferWorker(ITransferRepository TransferRepository, IMapper mapper)
        {
            _TransferRepository = TransferRepository;
            _TransferValidator = new TransferValidator();
            _rangeFilterValidator = new RangeFilterValidation();
            _mapper = mapper;
        }

        public async Task<Response<TransferResponse>> CreateTransfer(Transfer transfer)
        {
            var validation = _TransferValidator.Validate(transfer);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.ToImmutableList();
                return new Response<TransferResponse>
                {
                    Code = ResponseHttpCode.BadRequest,
                    Message = ValidationMessageFactory.GetValidationMessage(errors)
                };
            }

            transfer.ExternalId = Guid.NewGuid();

                await _TransferRepository.Create(transfer);

                var result = new Response<TransferResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<TransferResponse>(transfer)
                };

                return result;
            
        }

        public async Task DeleteTransfer(Guid id)
        {
            await _TransferRepository.Delete(id);
        }

        public async Task<Response<TransferResponse>> GetTransferById(Guid id)
        {
            try
            {
                var Transfer = await _TransferRepository.Read(id);

                var result = new Response<TransferResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<TransferResponse>(Transfer)
                };

                return result;
            }
            catch (KeyNotFoundException)
            {
                return new Response<TransferResponse>
                {
                    Code = ResponseHttpCode.NotFound,
                    Message = ResponseMessages.ObjectNotFound404
                };
            }
        }

        public async Task<CollectionResponse<TransferResponse>> ListTransfersInRange(DateRangeFilter rangefilter)
        {
            try
            {
                var Transfers = await _TransferRepository.List(rangefilter);

                var result = new CollectionResponse<TransferResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<List<TransferResponse>>(Transfers)
                };

                return result;
            }
            catch (KeyNotFoundException)
            {
                return new CollectionResponse<TransferResponse>
                {
                    Code = ResponseHttpCode.NotFound,
                    Message = ResponseMessages.ObjectNotFound404
                };
            }
        }

        public async Task<Response<TransferResponse>> UpdateTransfer(Transfer transfer)
        {
            var validation = _TransferValidator.Validate(transfer);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.ToImmutableList();
                return new Response<TransferResponse>
                {
                    Code = ResponseHttpCode.BadRequest,
                    Message = ValidationMessageFactory.GetValidationMessage(errors)
                };
            }
            
            try
            {
                await _TransferRepository.Update(transfer);

                var result = new Response<TransferResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<TransferResponse>(transfer)
                };

                return result;
            }
            catch (KeyNotFoundException)
            {
                return new Response<TransferResponse>
                {
                    Code = ResponseHttpCode.NotFound,
                    Message = ResponseMessages.ObjectNotFound404
                };
            }
        }
    }
}