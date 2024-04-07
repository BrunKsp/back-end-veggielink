using aplication.Dtos.Products;
using aplication.Services;
using Microsoft.AspNetCore.Mvc;
using VeggieLink.Aplication.Dtos.Products;

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
        [HttpGet("/all")]
        public async Task<List<ListProductDto>> GetAllProducts()
        {
            return await _service.GetAllProducts();

        }
        [HttpGet]
        public async Task<ListProductDto> GetProduct([FromQuery] string id)
        {
            return await _service.GetProduct(id);
        }
        [HttpPut]
        public async Task<IActionResult> ChangeProduct([FromBody] ChangeProductDto dto, [FromQuery] string id)
        {
            await _service.ChangeProduct(dto,id);
            return Ok("Alterado Com Sucesso");
        }
    }
}