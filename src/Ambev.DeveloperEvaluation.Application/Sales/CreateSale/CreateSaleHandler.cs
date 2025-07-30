using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;

        public CreateSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale(request.CustomerId, request.CustomerName, request.BranchId, request.BranchName);

            foreach (var item in request.Items)
            {
                sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
            }

            await _saleRepository.CreateAsync(sale, cancellationToken);

            return new CreateSaleResult(sale.Id);
        }
    }

}
