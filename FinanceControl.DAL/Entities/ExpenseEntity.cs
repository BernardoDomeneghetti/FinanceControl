using FinanceControl.Domain.Models.Business;

namespace FinanceControl.DAL.Entities;

public class ExpenseEntity: TransactionEntity
{
    public  string Description { get; set; } = string.Empty;
    public required int CategoryId { get; set; }
    public required CategoryEntity Category { get; set; }
}
