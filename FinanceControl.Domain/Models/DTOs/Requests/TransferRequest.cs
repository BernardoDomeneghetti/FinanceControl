namespace FinanceControl.Domain.Models.DTOs.Requests;

public class TransferRequest : TransactionRequest 
{
    public int TargetAccountId { get; set; }
}
