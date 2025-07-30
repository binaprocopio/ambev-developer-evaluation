using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.BranchId).NotEmpty();
            RuleFor(x => x.Items).NotEmpty().WithMessage("At least one item is required");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(x => x.ProductId).NotEmpty();
                item.RuleFor(x => x.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
                item.RuleFor(x => x.UnitPrice).GreaterThan(0);
            });
        }
    }

}
