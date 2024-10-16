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

        public async Task<ReceiveResponse> CreateReceive(Receive receive)
        {
            var validation = _ReceiveValidator.Validate(receive);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            await _ReceiveRepository.Create(receive);

            var result = new ReceiveResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyCreated201,
                Payload = receive
            };

            return result;
        }

        public async Task DeleteReceive(Guid id)
        {
            await _ReceiveRepository.Delete(id);
        }

        public async Task<ReceiveResponse> GetReceiveById(Guid id)
        {
            await _ReceiveRepository.Read(id);

            var result = new ReceiveResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyRead200,
            };

            return result;
        }

        public async Task<CollectionResponse<Receive>> ListReceivesInRange(DateRangeFilter rangefilter)
        {
            var validation = _rangeFilterValidator.Validate(rangefilter);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            var Receives = await _ReceiveRepository.List(rangefilter);

            var result = new CollectionResponse<Receive>
            {
                Message = ResponseMessages.ObjectSuccessfullyRead200,
                Payload = [.. Receives]
            };

            return result;
        }

        public async Task<ReceiveResponse> UpdateReceive(Receive receive)
        {
            var validation = _ReceiveValidator.Validate(receive);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            await _ReceiveRepository.Update(receive);

            var result = new ReceiveResponse
            {
                Message = ResponseMessages.ObjectSussessfullyUpdated200,
                Payload = receive
            };

            return result;
        }
    }
}