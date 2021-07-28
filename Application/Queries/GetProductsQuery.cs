using Core;
using Core.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetProductsQuery : IRequest<PagedList<Product>>
    {
        public ProductParams Params { get; set; }
        public GetProductsQuery(ProductParams productParams)
        {
            Params = productParams;
        }
    }
}