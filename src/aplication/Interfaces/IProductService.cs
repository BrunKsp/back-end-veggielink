using aplication.Dtos.Products;

namespace aplication.Services;

public interface IProductService
{
    Task Create(CreateProductDto dto);
}