namespace FinanceControl.DAL.Entities;

public class ExpenseEntity: TransactionEntity
{
    public required string Description { get; set; } = string.Empty;
    public required int CategoryId { get; set; }
}
