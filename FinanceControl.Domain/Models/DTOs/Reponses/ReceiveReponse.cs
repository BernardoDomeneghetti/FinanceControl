using FinanceControl.Domain.Models.Business;

namespace FinanceControl.Domain.Models.DTOs.Reponses;

public class ReceiveResponse : TransactionResponse
{
    public required string Description { get; set; } = string.Empty;
    public required Category Category { get; set; }
}
