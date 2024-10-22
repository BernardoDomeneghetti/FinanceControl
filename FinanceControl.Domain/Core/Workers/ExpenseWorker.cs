using System.Collections.Immutable;
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
    public class ExpenseWorker : IExpenseWorker
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ExpenseValidator _expenseValidator;
        private readonly RangeFilterValidation _rangeFilterValidator;

        public ExpenseWorker(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseValidator = new ExpenseValidator();
            _rangeFilterValidator = new RangeFilterValidation();
        }

        public async Task<ExpenseResponse> CreateExpense(Expense expense)
        {
            var validation = _expenseValidator.Validate(expense);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            expense.ExternalId = Guid.NewGuid();

            await _expenseRepository.Create(expense);

            var result = new ExpenseResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                Payload = expense
            };

            return result;
        }

        public async Task DeleteExpense(Guid id)
        {
            await _expenseRepository.Delete(id);
        }

        public async Task<ExpenseResponse> GetExpenseById(Guid id)
        {
            var expense = await _expenseRepository.Read(id);

            var result = new ExpenseResponse
            {
                Message = expense != null 
                    ? ResponseMessages.ObjectSuccessfullyRead200 
                    : ResponseMessages.ObjectNotFound404,
                Payload = expense
            };

            return result;
        }

        public async Task<ImmutableList<Expense>> ListExpensesInRange(DateRangeFilter rangefilter)
        {
            var validation = _rangeFilterValidator.Validate(rangefilter);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            var expenses = await _expenseRepository.List(rangefilter);
            return expenses;
        }

        public async Task<ExpenseResponse> UpdateExpense(Expense expense)
        {
            var validation = _expenseValidator.Validate(expense);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            await _expenseRepository.Update(expense);

            var result = new ExpenseResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyCreated201,
                Payload = expense
            };

            return result;
        }
    }
}