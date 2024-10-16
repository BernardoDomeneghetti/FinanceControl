namespace FinanceControl.DAL.Entities;

public class TransferEntity : TransactionEntity
{
    public required int TargetAccountId { get; set; }
}
