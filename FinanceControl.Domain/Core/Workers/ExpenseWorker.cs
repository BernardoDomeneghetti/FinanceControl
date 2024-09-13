using FinanceControl.Common.Models;
using FinanceControl.Common.Resources;
using FinanceControl.Comon.Resources;
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

        public ExpenseResponse CreateExpense(Expense expense)
        {
            var validation = _expenseValidator.Validate(expense);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            _expenseRepository.Create(expense);

            var result = new ExpenseResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyCreated201,
                Payload = expense
            };

            return result;
        }

        public void DeleteExpense(Guid id)
        {
            _expenseRepository.Delete(id);
        }

        public ExpenseResponse GetExpenseById(Guid id)
        {
            _expenseRepository.Read(id);

            var result = new ExpenseResponse
            {
                Message = ResponseMessages.ObjectSucessfullyRead200,
            };

            return result;
        }

        public CollectionResponse<Expense> ListExpensesInRange(DateRangeFilter rangefilter)
        {
            var validation = _rangeFilterValidator.Validate(rangefilter);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            var expenses = _expenseRepository.List(rangefilter);

            var result = new CollectionResponse<Expense>
            {
                Message = ResponseMessages.ObjectSucessfullyRead200,
                Payload = [.. expenses]
            };

            return result;
        }

        public ExpenseResponse UpdateExpense(Expense expense)
        {
            var validation = _expenseValidator.Validate(expense);

            if (!validation.IsValid)
                throw new BadRequestException(ErrorMessages.ValidationFailure, validation.Errors);

            _expenseRepository.Update(expense);

            var result = new ExpenseResponse
            {
                Message = ResponseMessages.ObjectSuccessfullyUpdated200,
                Payload = expense
            };

            return result;
        }
    }
}