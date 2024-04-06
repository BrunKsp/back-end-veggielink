using data.domain.Collections;

namespace infra.Interfaces;

public interface IProductRepository
{
    Task Create(ProductCollection collection);
    Task<ProductCollection> GetProduct(string id);
    Task UpdateStatus(string id);
}