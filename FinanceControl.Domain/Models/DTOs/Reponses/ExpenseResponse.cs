using FinanceControl.Domain.Models.Business;

namespace FinanceControl.Domain.Models.DTOs.Reponses;

public class ExpenseResponse : TransactionResponse
{
    public required string Description { get; set; } = string.Empty;
    public required Category Category { get; set; }
}
