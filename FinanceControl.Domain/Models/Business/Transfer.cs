namespace FinanceControl.Domain.Models.Business;

public sealed class Transfer: Transaction
{
    public required Account TargetAccount { get; set; }
}
