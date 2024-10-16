namespace FinanceControl.DAL.Entities;

public class TransactionEntity
{
    public required int Id { get; set; } 
    public required double Value { get; set; }
    public required DateTime Date { get; set; }
    public required int TransactionId { get; set; }
}
