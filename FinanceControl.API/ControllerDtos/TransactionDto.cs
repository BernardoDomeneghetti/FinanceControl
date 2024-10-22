namespace FinanceControl.API.ControllerDtos;

public abstract class TransactionDto
{
    public Guid Id { get; set; }
    public required double Value { get; set; }
    public required DateTime Date { get; set; }
    public int OriginAccountId { get; set; }

}
