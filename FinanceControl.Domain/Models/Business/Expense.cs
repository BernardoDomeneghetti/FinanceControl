namespace FinanceControl.Domain.Models.Business;

public sealed class Expense : Transaction
{
    public string Identifier { get; set; } = string.Empty;
}
