using FinanceControl.Domain.Models.Business;

namespace FinanceControl.Domain.Models.DTOs.Reponses;

public class TransferResponse : TransactionResponse 
{
    public required Account  TargetAccount { get; set; }
}
