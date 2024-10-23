using FinanceControl.Domain.Models.Business;

namespace FinanceControl.Domain.Models.DTOs.Requests;

public class AccountRequest
{
    public required string AccountName { get; set; } = string.Empty;
    public required int Bank { get; set; }
    public required AccountType AccountType { get; set; }
    public required double InitialValue { get; set; }
}
