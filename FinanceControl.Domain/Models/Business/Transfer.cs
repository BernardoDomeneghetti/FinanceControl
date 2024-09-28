using System;

namespace FinanceControl.Domain.Models.Business;

public sealed class Transfer: Transaction
{
    public Transfer(Account originAccount, Account targeAccount, double value)
    {
        OriginAccount = originAccount;
        TargeAccount = targeAccount;
        Value = value;
    }

    public Account OriginAccount { get; set; }
    public Account TargeAccount { get; set; }
}
