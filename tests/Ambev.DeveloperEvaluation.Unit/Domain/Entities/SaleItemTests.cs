using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleItemTests
    {
        [Theory]
        [InlineData(1, 100, 0)]
        [InlineData(3, 100, 0)]
        [InlineData(4, 100, 40)]
        [InlineData(9, 100, 90)]
        [InlineData(10, 100, 200)]
        [InlineData(20, 100, 400)]
        public void Should_Apply_Correct_Discount(int quantity, decimal unitPrice, decimal expectedDiscount)
        {
            var item = new SaleItem(Guid.NewGuid(), "Produto", quantity, unitPrice);

            item.Discount.Should().Be(expectedDiscount);
        }

        [Theory]
        [InlineData(1, 100, 100)]
        [InlineData(4, 100, 360)]
        [InlineData(10, 100, 800)]
        public void Should_Calculate_Correct_Total(int quantity, decimal unitPrice, decimal expectedTotal)
        {
            var item = new SaleItem(Guid.NewGuid(), "Produto", quantity, unitPrice);

            item.Total.Should().Be(expectedTotal);
        }

        [Fact]
        public void Should_Throw_When_Quantity_Is_Less_Than_1()
        {
            Action act = () => new SaleItem(Guid.NewGuid(), "Produto", 0, 100);

            act.Should().Throw<InvalidOperationException>()
               .WithMessage("Quantity must be at least 1.");
        }

        [Fact]
        public void Should_Throw_When_Quantity_Is_Greater_Than_20()
        {
            Action act = () => new SaleItem(Guid.NewGuid(), "Produto", 21, 100);

            act.Should().Throw<InvalidOperationException>()
               .WithMessage("You cannot purchase more than 20 identical items.");
        }
    }
}
