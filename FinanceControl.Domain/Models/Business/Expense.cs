namespace FinanceControl.Domain.Models.Business;

public sealed class Expense : Transaction
{
    public required string Description { get; set; } = string.Empty;
    public required Category Category { get; set; }
}
