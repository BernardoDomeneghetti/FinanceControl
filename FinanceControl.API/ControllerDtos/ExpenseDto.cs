namespace FinanceControl.API.ControllerDtos;

public class ExpenseDto : TransactionDto
{
    public required string Identifier { get; set; } = string.Empty;
    public required int CategoryId { get; set; }
}
