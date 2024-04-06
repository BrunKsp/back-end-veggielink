using data.domain.Collections;
using data.domain.Context;
using infra.Interfaces;
using MongoDB.Driver;

namespace infra.Repositories;

public class ProductRepository : IProductRepository
{
    protected IMongoCollection<ProductCollection> _dataBase;

    public ProductRepository(DbContext context)
    {
        _dataBase = context.ProductCollection;
    }

    public async Task Create(ProductCollection collection)
    {
        await _dataBase.InsertOneAsync(collection);
    }
    public async Task<ProductCollection> GetProduct(string id)
    {
        var filtro = Builders<ProductCollection>.Filter.Eq(x => x.Id, id);
        return await _dataBase.Find(t => t.Id.ToLower() == id.ToLower()).FirstOrDefaultAsync();
    }
    public async Task UpdateStatus(string id)
    {
        var filter = Builders<ProductCollection>.Filter.Eq(t => t.Id, id);
        var update = Builders<ProductCollection>.Update.Set(t => t.Status, 0);

        await _dataBase.UpdateOneAsync(filter, update);
    }
}