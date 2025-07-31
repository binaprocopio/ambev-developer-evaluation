namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCanceledEvent
    {
        public Guid SaleId { get; set; }

        public SaleCanceledEvent(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}
