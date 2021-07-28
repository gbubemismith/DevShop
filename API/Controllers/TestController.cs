using System.Threading.Tasks;
using Application.Queries;
using Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> GetProductsCQRS([FromQuery] ProductParams productParams)
        {
            var query = new GetProductsQuery(productParams);

            var products = await _mediator.Send(query);

            return Ok(products);
        }
    }
}