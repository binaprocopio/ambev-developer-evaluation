using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IBus _bus;

        public CreateSaleHandler(ISaleRepository saleRepository, IBus bus)
        {
            _saleRepository = saleRepository;
            _bus = bus;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale(request.CustomerId, request.CustomerName, request.BranchId, request.BranchName);

            foreach (var item in request.Items)
            {
                sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
            }

            await _saleRepository.CreateAsync(sale, cancellationToken);

            var saleCreatedEvent = new SaleRegisteredEvent(
                sale.Id,
                sale.SaleNumber,
                sale.CustomerId,
                sale.CustomerName,
                sale.SaleDate
            );

            await _bus.Publish(saleCreatedEvent);

            return new CreateSaleResult(sale.Id);
        }
    }

}
