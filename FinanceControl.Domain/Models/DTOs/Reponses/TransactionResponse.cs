namespace FinanceControl.Domain.Models.DTOs.Reponses;

public abstract class TransactionResponse
{
    public Guid Id { get; set; }
    public required AccountResponse OriginAccount { get; set; }
    public required double Value { get; set; }
    public required DateTime Date { get; set; }

}
