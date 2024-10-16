namespace FinanceControl.API.ControllerDtos;

public abstract class TransactionDto
{
    public required double Value { get; set; }
    public required DateTime Date { get; set; }
}
