
using FinanceControl.Common.Consts;
using FinanceControl.Domain.Models.Business;
using FluentValidation;

namespace FinanceControl.Domain.Core.Validators
{
    public class ReceiveValidator : AbstractValidator<Receive>
    {
        public ReceiveValidator()
        {
            RuleFor(Receive => Receive.Value).GreaterThan(0).WithMessage("ErrorMessages.TransactionValidationValueGreaterThanZero");

            RuleFor(Receive => Receive.Date).GreaterThan(new DateTime(2000, 01, 01, 00, 00, 00, DateTimeKind.Utc)).WithMessage(ErrorMessages.InvalidTransactionDateTime);
            RuleFor(Receive => Receive.Description).NotNull().NotEmpty().WithMessage(ErrorMessages.EmptyOrNullTransactionIdentifier);
        }
    }
}