using data.domain.Collections;

namespace VeggieLink.Infra.Interfaces;

public interface IProductRepository
{
    Task Create(ProductCollection collection);
    Task<List<ProductCollection>> GetAllProducts();
    Task<ProductCollection> GetProduct(string id);
    Task UpdateStatus(string id);
    Task UpdateProduct(ProductCollection dto, string id);
}