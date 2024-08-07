using FinnanceControll.Interfaces.Models;

namespace FinnanceControll.Models.Domain
{
    public abstract class Transaction : ICustomData
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}