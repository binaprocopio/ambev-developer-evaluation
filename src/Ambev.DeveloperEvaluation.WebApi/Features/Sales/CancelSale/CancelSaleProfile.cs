using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale
{
    public class CancelSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CancelSale feature
        /// </summary>
        public CancelSaleProfile()
        {
            CreateMap<Guid, Application.Sales.CancelSale.CancelSaleCommand>()
                .ConstructUsing(id => new Ambev.DeveloperEvaluation.Application.Sales.CancelSale.CancelSaleCommand(id));

            CreateMap<SaleItemResult, SaleItemResponse>();
            CreateMap<CancelSaleResult, CancelSaleResponse>();
        }
    }
}