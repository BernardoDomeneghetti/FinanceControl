

using FinanceControl.Common.Resources;
using FinanceControl.Domain.Models.Business;
using FluentValidation;

namespace FinanceControl.Domain.Core.Validators
{
    public class TransferValidator : AbstractValidator<Transfer>
    {
        public TransferValidator()
        {
            RuleFor(Transfer => Transfer.Value).GreaterThan(0).WithMessage(ErrorMessages.TransactionValidationValueGreaterThanZero);

            RuleFor(Transfer => Transfer.Date).GreaterThan(new DateTime(2000, 01, 01, 00, 00, 00, DateTimeKind.Utc)).WithMessage(ErrorMessages.InvalidTransactionDateTime);
        }
    }
}