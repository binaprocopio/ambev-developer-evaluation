using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Bus;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IBus _bus;
        private ILogger<CancelSaleHandler> _logger;

        public CancelSaleHandler(ISaleRepository saleRepository, IBus bus, ILogger<CancelSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _bus = bus;
            _logger = logger;
        }

        public async Task<CancelSaleResult> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);

                if (sale == null)
                {
                    _logger.LogWarning("Sale with ID {0} not found.", request.SaleId);
                    throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found.");
                }

                sale.Cancel();
                await _saleRepository.UpdateAsync(sale, cancellationToken);

                var saleCreatedEvent = new SaleCanceledEvent(sale.Id);

                _logger.LogInformation("Publishing event of sale {0} canceled.", sale.Id);

                await _bus.Publish(saleCreatedEvent);

                return new CancelSaleResult(sale.Id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on cancel sale.");
                throw new ApplicationException("Error on cancel sale.", ex);
            }
        }
    }
}