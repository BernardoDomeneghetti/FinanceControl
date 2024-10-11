using System;

namespace FinanceControl.Domain.Models.Business;

public sealed class Transfer: Transaction
{
    public required Account OriginAccount { get; set; }
    public required Account TargeAccount { get; set; }
}
