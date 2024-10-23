namespace FinanceControl.Domain.Models.DTOs.Requests;

public abstract class TransactionRequest
{
    public int OriginAccountId { get; set; }
    public required double Value { get; set; }
    public required DateTime Date { get; set; }

}
