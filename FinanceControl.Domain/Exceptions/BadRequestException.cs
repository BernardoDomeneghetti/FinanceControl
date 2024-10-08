﻿using FluentValidation.Results;
using System.Collections.Immutable;

namespace FinanceControl.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public readonly ImmutableList<ValidationFailure> ValidationFailures;

        public BadRequestException(string? message, List<ValidationFailure> validationFailures) : base(message)
        {
            ValidationFailures = [.. validationFailures];
        }
    }
}