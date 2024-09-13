namespace FinanceControl.Domain.Models.Business;
public abstract class Transaction
{
    public Guid Id { get; set; }
    public double Value { get; set; }
    public DateTime Date { get; set; }
}
