namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleResult
    {
        public Guid Id { get; }

        public CancelSaleResult(Guid saleId)
        {
            Id = saleId;
        }
    }
}
