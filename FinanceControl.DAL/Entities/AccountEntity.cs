namespace FinanceControl.DAL.Entities;

public class AccountEntity
{
    public int Id { get; set;}
    public string AccountName { get; set; } = string.Empty;
    public double InitialValue { get; set; }
    public int Bank { get; set; }
    public int AccountType { get; set; }

}
