using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public long SaleNumber { get; private set; }
        public DateTime SaleDate { get; private set; }

        public Guid CustomerId { get; private set; }
        public string CustomerName { get; private set; }

        public Guid BranchId { get; private set; }
        public string BranchName { get; private set; }

        public bool IsCanceled { get; private set; }

        private readonly List<SaleItem> _items = new();
        public IReadOnlyCollection<SaleItem> Items => _items;

        public decimal TotalAmount => _items.Sum(i => i.Total);

        protected Sale() { }

        public Sale(Guid customerId, string customerName, Guid branchId, string branchName)
        {
            Id = Guid.NewGuid();
            SaleDate = DateTime.UtcNow;
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            IsCanceled = false;
        }

        public void AddItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            if (_items.Any(i => i.ProductId == productId))
                throw new InvalidOperationException("Product already added to sale.");

            var item = new SaleItem(productId, productName, quantity, unitPrice);
            _items.Add(item);
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}
