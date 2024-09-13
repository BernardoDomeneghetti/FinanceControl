

using FinanceControl.Common.Resources;
using FinanceControl.Domain.Models.Business;
using FluentValidation;

namespace FinanceControl.Domain.Core.Validators
{
    public class ExpenseValidator : AbstractValidator<Expense>
    {
        public ExpenseValidator()
        {
            RuleFor(expense => expense.Value).GreaterThan(0).WithMessage(ErrorMessages.TransactionValidationValueGreaterThanZero);

            RuleFor(expense => expense.Date).GreaterThan(new DateTime(2000, 01, 01, 00, 00, 00, DateTimeKind.Utc)).WithMessage(ErrorMessages.InvalidTransactionDateTime);
            RuleFor(expense => expense.Identifier).NotNull().NotEmpty().WithMessage(ErrorMessages.EmptyOrNullTransactionIdentifier);
        }
    }
}