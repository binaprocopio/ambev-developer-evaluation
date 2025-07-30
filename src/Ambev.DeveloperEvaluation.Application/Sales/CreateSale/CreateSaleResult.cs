namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        public Guid SaleId { get; }

        public CreateSaleResult(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}
