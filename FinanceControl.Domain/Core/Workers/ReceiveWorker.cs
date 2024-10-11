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
    public class ReceiveWorker : IReceiveWorker
    {
        private readonly IReceiveRepository _ReceiveRepository;
        private readonly ReceiveValidator _ReceiveValidator;
        private readonly RangeFilterValidation _rangeFilterValidator;

        public ReceiveWorker(IReceiveRepository ReceiveRepository)
        {
            _ReceiveRepository = ReceiveRepository;
            _ReceiveValidator = new ReceiveValidator();
            _rangeFilterValidator = new RangeFilterValidation();
        }

        public ReceiveResponse CreateReceive(Receive Receive)
        {
            var validation = _ReceiveValidator.Validate(Receive);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            _ReceiveRepository.Create(Receive);

            var result = new ReceiveResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyCreated201,
                Payload = Receive
            };

            return result;
        }

        public void DeleteReceive(Guid id)
        {
            _ReceiveRepository.Delete(id);
        }

        public ReceiveResponse GetReceiveById(Guid id)
        {
            _ReceiveRepository.Read(id);

            var result = new ReceiveResponse
            {
                Message = ResponseMessages.ObjectSucessfullyRead200,
            };

            return result;
        }

        public CollectionResponse<Receive> ListReceivesInRange(DateRangeFilter rangefilter)
        {
            var validation = _rangeFilterValidator.Validate(rangefilter);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            var Receives = _ReceiveRepository.List(rangefilter);

            var result = new CollectionResponse<Receive>
            {
                Message = ResponseMessages.ObjectSucessfullyRead200,
                Payload = [.. Receives]
            };

            return result;
        }

        public ReceiveResponse UpdateReceive(Receive Receive)
        {
            var validation = _ReceiveValidator.Validate(Receive);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            _ReceiveRepository.Update(Receive);

            var result = new ReceiveResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyUpdated200,
                Payload = Receive
            };

            return result;
        }
    }
}