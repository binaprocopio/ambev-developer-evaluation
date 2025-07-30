using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        private readonly Faker _faker = new();

        private Sale CreateSale()
        {
            return new Sale(
                customerId: Guid.NewGuid(),
                customerName: _faker.Person.FullName,
                branchId: Guid.NewGuid(),
                branchName: _faker.Company.CompanyName());
        }

        [Fact]
        public void Should_Add_Item_Without_Discount_When_Quantity_Is_Less_Than_4()
        {
            var sale = CreateSale();
            var unitPrice = 100m;
            var quantity = 3;

            sale.AddItem(Guid.NewGuid(), "Mouse", quantity, unitPrice);

            var item = sale.Items.Single();
            item.Discount.Should().Be(0);
            item.Total.Should().Be(unitPrice * quantity);
        }

        [Fact]
        public void Should_Apply_10Percent_Discount_When_Quantity_Is_Between_4_And_9()
        {
            var sale = CreateSale();
            var unitPrice = 200m;
            var quantity = 5;

            sale.AddItem(Guid.NewGuid(), "Keyboard", quantity, unitPrice);

            var item = sale.Items.Single();
            item.Discount.Should().Be(unitPrice * quantity * 0.10m);
        }

        [Fact]
        public void Should_Apply_20Percent_Discount_When_Quantity_Is_Between_10_And_20()
        {
            var sale = CreateSale();
            var unitPrice = 300m;
            var quantity = 15;

            sale.AddItem(Guid.NewGuid(), "Monitor", quantity, unitPrice);

            var item = sale.Items.Single();
            item.Discount.Should().Be(unitPrice * quantity * 0.20m);
        }

        [Fact]
        public void Should_Throw_When_Quantity_Is_Above_20()
        {
            var sale = CreateSale();
            var unitPrice = 150m;
            var quantity = 21;

            var act = () => sale.AddItem(Guid.NewGuid(), "SSD", quantity, unitPrice);

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("You cannot purchase more than 20 identical items.");
        }

        [Fact]
        public void Should_Calculate_TotalAmount_Correctly_With_Multiple_Items()
        {
            var sale = CreateSale();

            sale.AddItem(Guid.NewGuid(), "Item A", 3, 100m);
            sale.AddItem(Guid.NewGuid(), "Item B", 5, 100m);
            sale.AddItem(Guid.NewGuid(), "Item C", 15, 100m);

            var total = sale.TotalAmount;

            const decimal expectedTotal = (100m * 3) +
                                (100m * 5 * 0.90m) +
                                (100m * 15 * 0.80m);

            total.Should().Be(expectedTotal);
        }

        [Fact]
        public void Should_Mark_Sale_As_Cancelled()
        {
            var sale = CreateSale();
            sale.Cancel();
            sale.IsCanceled.Should().BeTrue();
        }
    }
}
