namespace FinanceControl.DAL.Entities;

public class TransactionEntity
{
    public int Id { get; set; }
    public  Guid ExternalId { get; set; } 
    public  double Value { get; set; }
    public  DateTime Date { get; set; }
    public  int OriginAccountId { get; set; }
    public required AccountEntity OriginAccount { get; set; }
}
