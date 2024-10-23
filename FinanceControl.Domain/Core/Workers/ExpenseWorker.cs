using System.Collections.Immutable;
using AutoMapper;
using FinanceControl.Common.Consts;
using FinanceControl.Common.Models;
using FinanceControl.Domain.Core.Validators;
using FinanceControl.Domain.Helpers;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.DTOs;
using FinanceControl.Domain.Models.DTOs.BaseDtos;
using FinanceControl.Domain.Models.DTOs.Reponses;

namespace FinanceControl.Domain.Core.Workers
{
    public class ExpenseWorker : IExpenseWorker
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ExpenseValidator _expenseValidator;
        private readonly RangeFilterValidation _rangeFilterValidator;
        private readonly IMapper _mapper;

        public ExpenseWorker(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _expenseValidator = new ExpenseValidator();
            _rangeFilterValidator = new RangeFilterValidation();
            _mapper = mapper;
        }

        public async Task<Response<ExpenseResponse>> CreateExpense(Expense expense)
        {
            var validation = _expenseValidator.Validate(expense);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.ToImmutableList();
                return new Response<ExpenseResponse>
                {
                    Code = ResponseHttpCode.BadRequest,
                    Message = ValidationMessageFactory.GetValidationMessage(errors)
                };
            }

            expense.ExternalId = Guid.NewGuid();

                await _expenseRepository.Create(expense);

                var result = new Response<ExpenseResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<ExpenseResponse>(expense)
                };

                return result;
            
        }

        public async Task DeleteExpense(Guid id)
        {
            await _expenseRepository.Delete(id);
        }

        public async Task<Response<ExpenseResponse>> GetExpenseById(Guid id)
        {
            try
            {
                var expense = await _expenseRepository.Read(id);

                var result = new Response<ExpenseResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<ExpenseResponse>(expense)
                };

                return result;
            }
            catch (KeyNotFoundException)
            {
                return new Response<ExpenseResponse>
                {
                    Code = ResponseHttpCode.NotFound,
                    Message = ResponseMessages.ObjectNotFound404
                };
            }
        }

        public async Task<CollectionResponse<ExpenseResponse>> ListExpensesInRange(DateRangeFilter rangefilter)
        {
            var validation = _rangeFilterValidator.Validate(rangefilter);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.ToImmutableList();
                return new CollectionResponse<ExpenseResponse>
                {
                    Code = ResponseHttpCode.BadRequest,
                    Message = ValidationMessageFactory.GetValidationMessage(errors)
                };
            }
            try
            {
                var expenses = await _expenseRepository.List(rangefilter);

                var result = new CollectionResponse<ExpenseResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<List<ExpenseResponse>>(expenses)
                };

                return result;
            }
            catch (KeyNotFoundException)
            {
                return new CollectionResponse<ExpenseResponse>
                {
                    Code = ResponseHttpCode.NotFound,
                    Message = ResponseMessages.ObjectNotFound404
                };
            }
        }

        public async Task<Response<ExpenseResponse>> UpdateExpense(Expense expense)
        {
            var validation = _expenseValidator.Validate(expense);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.ToImmutableList();
                return new Response<ExpenseResponse>
                {
                    Code = ResponseHttpCode.BadRequest,
                    Message = ValidationMessageFactory.GetValidationMessage(errors)
                };
            }

            try
            {
                await _expenseRepository.Update(expense);

                var result = new Response<ExpenseResponse>
                {
                    Code = ResponseHttpCode.Created,
                    Message = ResponseMessages.ObjectSuccessfullyCreated201, 
                    Payload = _mapper.Map<ExpenseResponse>(expense)
                };

                return result;
            }
            catch (KeyNotFoundException)
            {
                return new Response<ExpenseResponse>
                {
                    Code = ResponseHttpCode.NotFound,
                    Message = ResponseMessages.ObjectNotFound404
                };
            }
        }
    }
}