using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductsController(IProductService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;

        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParams productParams)
        {
            var products = await _service.GetProductsAsync(productParams);

            if (products == null)
                return NotFound(new ApiResponse(404));

            var data = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(products.CurrentPage, products.PageSize, products.TotalCount, data));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _service.GetProductByIdAsync(id);

            if (product == null)
                return NotFound(new ApiResponse(404));

            var productToReturn = _mapper.Map<ProductToReturnDto>(product);

            return Ok(productToReturn);
        }
    }
}