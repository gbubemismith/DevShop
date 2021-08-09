using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Helpers;


namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _repo;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository repo)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _repo.GetProductBrandsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        public async Task<PagedList<Product>> GetProductsAsync(ProductParams productParams)
        {
            var productQuery = _repo.GetProductsAsync(productParams);

            return await ObjectPagedList<Product>.CreateAsync(productQuery, productParams.PageNumber, productParams.PageSize);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _repo.GetProductTypesAsync();
        }
    }
}