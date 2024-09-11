namespace FinnanceControll.Models.Domain
{
    public sealed class Expense : Transaction
    {
        public string Identifier { get; set; } = string.Empty;
    }
}
