namespace FinanceControl.Domain.Models.DTOs.Requests;

public class ReceiveRequest : TransactionRequest
{
    public required string Description { get; set; } = string.Empty;
    public required int CategoryId { get; set; }
}
