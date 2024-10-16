using FinanceControl.Common.Consts;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Core.Validators;
using FinanceControl.Domain.Exceptions;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.Responses;

namespace FinanceControl.Domain.Core.Workers
{
    public class TransferWorker : ITransferWorker
    {
        private readonly ITransferRepository _TransferRepository;
        private readonly TransferValidator _TransferValidator;
        private readonly RangeFilterValidation _rangeFilterValidator;

        public TransferWorker(ITransferRepository TransferRepository)
        {
            _TransferRepository = TransferRepository;
            _TransferValidator = new TransferValidator();
            _rangeFilterValidator = new RangeFilterValidation();
        }

        public async Task<TransferResponse> CreateTransfer(Transfer transfer)
        {
            var validation = _TransferValidator.Validate(transfer);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            await _TransferRepository.Create(transfer);

            var result = new TransferResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyCreated201,
                Payload = transfer
            };

            return result;
        }

        public async Task DeleteTransfer(Guid id)
        {
            await _TransferRepository.Delete(id);
        }

        public async Task<TransferResponse> GetTransferById(Guid id)
        {
            await _TransferRepository.Read(id);

            var result = new TransferResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyRead200,
            };

            return result;
        }

        public async Task<CollectionResponse<Transfer>> ListTransfersInRange(DateRangeFilter rangefilter)
        {
            var validation = _rangeFilterValidator.Validate(rangefilter);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            var Transfers = await _TransferRepository.List(rangefilter);

            var result = new CollectionResponse<Transfer>
            {
                Message = ResponseMessages.ObjectSuccessfullyRead200,
                Payload = [.. Transfers]
            };

            return result;
        }

        public async Task<TransferResponse> UpdateTransfer(Transfer transfer)
        {
            var validation = _TransferValidator.Validate(transfer);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            await _TransferRepository.Update(transfer);

            var result = new TransferResponse
            {
                Message = ResponseMessages.ObjectSussessfullyUpdated200,
                Payload = transfer
            };

            return result;
        }
    }
}