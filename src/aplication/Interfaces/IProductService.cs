using aplication.Dtos.Products;
using VeggieLink.Aplication.Dtos.Products;

namespace aplication.Services;

public interface IProductService
{
    Task Create(CreateProductDto dto);
    Task<List<ListProductDto>> GetAllProducts();
    Task<ListProductDto> GetProduct(string id);
    Task ChangeProduct(ChangeProductDto dto, string id);
}