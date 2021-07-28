using System.Threading;
using System.Threading.Tasks;
using Core;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Queries.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, PagedList<Product>>
    {
        private readonly IProductService _productService;
        public GetProductsHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<PagedList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productService.GetProductsAsync(request.Params);

            return productList;
        }
    }
}