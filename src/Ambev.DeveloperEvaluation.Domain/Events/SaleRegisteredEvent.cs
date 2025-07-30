namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleRegisteredEvent
    {
        public Guid SaleId { get; set; }
        public long SaleNumber { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }

        public SaleRegisteredEvent(Guid saleId, long saleNumber, Guid customerId, string customerName, DateTime createdAt)
        {
            SaleId = saleId;
            SaleNumber = saleNumber;
            CustomerId = customerId;
            CustomerName = customerName;
            CreatedAt = createdAt;
        }
    }
}
