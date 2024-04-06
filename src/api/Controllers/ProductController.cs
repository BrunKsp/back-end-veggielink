using aplication.Dtos.Products;
using aplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("products")]
    public class ProductController : BaseController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            await _service.Create(dto);
            return Ok("Criado Com Sucesso");
        }
    }
}