using AutoMapper;
using FinanceControl.Domain.Models.Business;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using FinanceControl.Common.Models;
using FinanceControl.DAL.Entities;
using FinanceControl.DAL.Interfaces;
using FinanceControl.Domain.Interfaces.Repositories;

namespace FinanceControl.DAL.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly IMapper _mapper;
    private readonly IDataContext _context;

    public ExpenseRepository(IMapper mapper, IDataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task Create(Expense expense)
    {
        var expenseEntity = _mapper.Map<ExpenseEntity>(expense);
        _context.Expenses.Add(expenseEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Expense expense)
    {
        var expenseEntity  = await _context.Expenses.AsNoTracking().FirstOrDefaultAsync (e => e.ExternalId == expense.ExternalId);
        
        if (expenseEntity == null)
        {
            throw new KeyNotFoundException(); //TODO: Create a custom exception
        }

        var updateExpense = _mapper.Map<ExpenseEntity>(expense);
        updateExpense.Id = expenseEntity.Id;

        _context.Expenses.Update(updateExpense);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid ExternalId)
    {
        var expenseEntity = await _context.Expenses.FirstOrDefaultAsync (e => e.ExternalId == ExternalId);
        if (expenseEntity != null)
        {
            _context.Expenses.Remove(expenseEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Expense> Read(Guid ExternalId)
    {
        var expenseEntity = await _context.Expenses.FirstOrDefaultAsync(e => e.ExternalId == ExternalId);
        return _mapper.Map<Expense>(expenseEntity);
    }

    public async Task<ImmutableList<Expense>> List(DateRangeFilter rangeFilter)
    {
        var query = _context.Expenses.AsQueryable();

        query = query.Where(e => e.Date >= rangeFilter.Since && e.Date <= rangeFilter.Until);

        var expenseEntities = await query.ToListAsync();
        var expenses = _mapper.Map<List<Expense>>(expenseEntities);

        return expenses.ToImmutableList();
    }
}