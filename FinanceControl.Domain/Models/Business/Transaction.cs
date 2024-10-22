namespace FinanceControl.Domain.Models.Business;
public abstract class Transaction
{
    public int Id { get; set; } 
    public Guid ExternalId { get; set; }
    public required double Value { get; set; }
    public required DateTime Date { get; set; }
    public required Account OriginAccount { get; set; }

}
