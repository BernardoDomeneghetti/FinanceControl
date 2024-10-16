namespace FinanceControl.API.ControllerDtos;

public class ReceiveDto : TransactionDto
{
    public required string Description { get; set; } = string.Empty;
    public required int CategoryId { get; set; }
}
