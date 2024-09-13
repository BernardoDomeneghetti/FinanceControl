using FinanceControl.Common.Models;
using FluentValidation;

namespace FinanceControl.Domain.Core.Validators
{
    public class RangeFilterValidation : AbstractValidator<DateRangeFilter>
    {
        public RangeFilterValidation()
        {
            RuleFor(range => range.Since).LessThan(range => range.Until);
            RuleFor(range => range.Since).GreaterThan(range => range.Until.AddMonths(-3));
        }
    }
}