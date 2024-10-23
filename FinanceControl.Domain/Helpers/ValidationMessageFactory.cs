using System.Collections.Immutable;
using FinanceControl.Common.Consts;

namespace FinanceControl.Domain.Helpers;

public static class ValidationMessageFactory
{
    public static string GetValidationMessage(ImmutableList<FluentValidation.Results.ValidationFailure> errors)
    {
        var concatenatedErrors = string.Join(", ", errors.Select(x => x.ErrorMessage));
        var formatedValidationMessage = string.Format(ErrorMessages.ValidationFailure, concatenatedErrors);

        return formatedValidationMessage;

    }
    
}
