using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context)
        {
            _context = context;

        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Product> GetProductsAsync(ProductParams productParams)
        {
            var products = _context.Products
                            .Include(p => p.ProductBrand)
                            .Include(p => p.ProductType).OrderBy(p => p.Name).AsQueryable();

            //sort by price
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        products = products.OrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        products = products.OrderByDescending(p => p.Price);
                        break;
                    default:
                        products = products.OrderBy(p => p.Name);
                        break;
                }
            }

            //add search functionality
            if (!string.IsNullOrEmpty(productParams.Search))
                products = products.Where(p => p.Name.ToLower().Contains(productParams.Search));

            //add brand id filter
            if (productParams.BrandId.HasValue)
                products = products.Where(p => p.ProductBrandId == productParams.BrandId);

            //add type id filter
            if (productParams.TypeId.HasValue)
                products = products.Where(p => p.ProductTypeId == productParams.TypeId);


            return products;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }
    }
}