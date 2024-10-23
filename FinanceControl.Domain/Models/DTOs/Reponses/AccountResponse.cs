using FinanceControl.Domain.Models.Business;

namespace FinanceControl.Domain.Models.DTOs.Reponses;

public class AccountResponse
{
    public string AccountName { get; set; } = string.Empty;
    public int Bank { get; set; }
    public AccountType AccountType { get; set; }
    public Guid Id { get; set; }
}
