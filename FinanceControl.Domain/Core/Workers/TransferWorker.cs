using FinanceControl.Common.Models;
using FinanceControl.Common.Resources;
using FinanceControl.Comon.Resources;
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

        public TransferResponse CreateTransfer(Transfer transfer)
        {
            var validation = _TransferValidator.Validate(transfer);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            _TransferRepository.Create(transfer);

            var result = new TransferResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyCreated201,
                Payload = transfer
            };

            return result;
        }

        public void DeleteTransfer(Guid id)
        {
            _TransferRepository.Delete(id);
        }

        public TransferResponse GetTransferById(Guid id)
        {
            _TransferRepository.Read(id);

            var result = new TransferResponse
            {
                Message = ResponseMessages.ObjectSucessfullyRead200,
            };

            return result;
        }

        public CollectionResponse<Transfer> ListTransfersInRange(DateRangeFilter rangefilter)
        {
            var validation = _rangeFilterValidator.Validate(rangefilter);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            var Transfers = _TransferRepository.List(rangefilter);

            var result = new CollectionResponse<Transfer>
            {
                Message = ResponseMessages.ObjectSucessfullyRead200,
                Payload = [.. Transfers]
            };

            return result;
        }

        public TransferResponse UpdateTransfer(Transfer transfer)
        {
            var validation = _TransferValidator.Validate(transfer);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            _TransferRepository.Update(transfer);

            var result = new TransferResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyUpdated200,
                Payload = transfer
            };

            return result;
        }
    }
}