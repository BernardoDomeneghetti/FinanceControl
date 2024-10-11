namespace FinanceControl.Domain.Models.Business;
public abstract class Transaction
{
    public required int Id { get; set; } 
    public required double Value { get; set; }
    public required DateTime Date { get; set; }

}
