namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public class SaleItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }

        public decimal Total => (Quantity * UnitPrice) - Discount;

        protected SaleItem() { }

        public SaleItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            if (quantity < 1)
                throw new InvalidOperationException("Quantity must be at least 1.");

            if (quantity > 20)
                throw new InvalidOperationException("You cannot purchase more than 20 identical items.");

            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = CalculateDiscount();
        }

        private decimal CalculateDiscount()
        {
            if (Quantity < 4) return 0;
            if (Quantity >= 10) return Quantity * UnitPrice * 0.20m;
            return Quantity * UnitPrice * 0.10m;
        }
    }
}
