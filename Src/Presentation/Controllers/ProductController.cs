using Application.Features.Product.UseCases.CreateProductUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly ICreateProductUseCase _createProductUseCase;

        public ProductController(ICreateProductUseCase createProductUseCase)
        {
            _createProductUseCase = createProductUseCase;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateProductInput input)
        {
            await _createProductUseCase.Execute(input);

            return Ok(input);
        }
    }
}
