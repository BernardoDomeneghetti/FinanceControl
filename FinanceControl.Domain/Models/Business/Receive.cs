namespace FinanceControl.Domain.Models.Business;

public sealed class Receive:Transaction
{
    public required string Identifier { get; set; }
    public required Category Category { get; set; }
}
