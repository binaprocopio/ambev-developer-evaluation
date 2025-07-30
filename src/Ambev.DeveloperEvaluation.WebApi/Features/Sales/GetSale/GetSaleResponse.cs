namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    /// <summary>
    /// API response model for GetSale operation
    /// </summary>
    public class GetSaleResponse
    {
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The number that identifies the sale
        /// </summary>
        public long SaleNumber { get; set; }

        /// <summary>
        /// The date of the sale
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// The unique identifier of the customer
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The name of the customer
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// The unique identifier for the branch
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// The name of the branch
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether the sale is canceled
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// The list of items in the sale
        /// </summary>
        private List<SaleItemResponse> Items { get; set; } = [];

        /// <summary>
        /// The total amount of the sale
        /// </summary>
        public decimal TotalAmount { get; set; }
    }

    public class SaleItemResponse
    {
        /// <summary>
        /// The unique identifier of the sale item
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique identifier of the product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// The quantity of the product sold
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the product
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The discount applied to the product
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// The total amount for this sale item
        /// </summary>
        public decimal Total { get; set; }
    }
}
