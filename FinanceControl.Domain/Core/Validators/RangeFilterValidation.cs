using FinanceControl.Common.Models;
using FluentValidation;

namespace FinanceControl.Domain.Core.Validators
{
    public class RangeFilterValidation : AbstractValidator<DateRangeFilter>
    {
        public RangeFilterValidation()
        {
            RuleFor(range => range.Since).LessThanOrEqualTo(range => range.Until);
            RuleFor(range => range.Since).GreaterThanOrEqualTo(range => range.Until.AddMonths(-3));
        }
    }
}