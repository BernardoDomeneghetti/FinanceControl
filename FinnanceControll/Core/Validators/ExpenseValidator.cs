using FinnanceControll.Models.Domain;
using FinnanceControll.Resources;
using FluentValidation;

namespace FinnanceControll.Core.Validators
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