namespace FinanceControl.Domain.Models.Business;

public class Account
{
    public int Id { get; set;}
    public Guid ExternalId { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public double InitialValue { get; set; }
    public int Bank { get; set; }
    public AccountType AccountType { get; set; }
}
