namespace FinanceControl.Domain.Models.Business;

public sealed class Receive:Transaction
{
    public string Identifier { get; set; } = string.Empty;
}
