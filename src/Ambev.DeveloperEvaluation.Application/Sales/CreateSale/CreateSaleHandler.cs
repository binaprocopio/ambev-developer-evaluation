using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Bus;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IBus _bus;
    private ILogger<CreateSaleHandler> _logger;

    public CreateSaleHandler(ISaleRepository saleRepository, IBus bus, ILogger<CreateSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _bus = bus;
        _logger = logger;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        try
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
            _logger.LogInformation("Publishing event of sale {0} created.", sale.Id);

            await _bus.Publish(saleCreatedEvent);

            return new CreateSaleResult(sale.Id);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error create sale.");
            throw new ApplicationException("Error create sale.", ex);
        }
    }
}
