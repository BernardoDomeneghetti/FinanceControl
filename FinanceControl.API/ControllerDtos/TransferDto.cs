namespace FinanceControl.API.ControllerDtos;

public class TransferDto : TransactionDto 
{
    public int TargetAccountId { get; set; }
}
