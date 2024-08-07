using FinnanceControll.Models.Common;
using FluentValidation;

namespace FinnanceControll.Core.Validators
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