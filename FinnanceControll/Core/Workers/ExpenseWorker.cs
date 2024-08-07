using FinnanceControll.Core.Validators;
using FinnanceControll.Exceptions;
using FinnanceControll.Interfaces.Repositories;
using FinnanceControll.Interfaces.Workers;
using FinnanceControll.Models.Common;
using FinnanceControll.Models.Domain;
using FinnanceControll.Models.Responses;
using FinnanceControll.Resources;

namespace FinnanceControll.Core.Workers
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