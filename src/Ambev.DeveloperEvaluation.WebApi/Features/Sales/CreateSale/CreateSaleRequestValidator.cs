using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleRequest that defines validation rules for sale creation.
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - CustomerId: NotEmpty
        /// </remarks>
        public CreateSaleRequestValidator()
        {
            RuleFor(sale => sale.CustomerId).NotEmpty();
            //Todo: build a validator for all fields in CreateSaleRequest
        }
    }
}