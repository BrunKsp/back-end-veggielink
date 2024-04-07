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
    public async Task<List<ProductCollection>> GetAllProducts()
    {
        return await _dataBase.Find(_ => true).ToListAsync();
    }
    public async Task<ProductCollection> GetProduct(string id)
    {
        var filter = Builders<ProductCollection>.Filter.Eq(p => p.Id, id);
        return await _dataBase.Find(filter).FirstOrDefaultAsync();
    }
    public async Task UpdateStatus(string id)
    {
        var filter = Builders<ProductCollection>.Filter.Eq(p => p.Id, id);
        var update = Builders<ProductCollection>.Update.Set(p => p.Status, 0);

        await _dataBase.UpdateOneAsync(filter, update);
    }
    public async Task UpdateProduct(ProductCollection dto, string id)
    {
        var filter = Builders<ProductCollection>.Filter.Eq(p => p.Id, id);

        var update = Builders<ProductCollection>.Update
            .Set(p => p.Name, dto.Name)
            .Set(p => p.Description, dto.Description)
            .Set(p => p.PlantingDate, dto.PlantingDate)
            .Set(p => p.HarverstDate, dto.HarverstDate)
            .Set(p => p.Status, dto.Status);

        await _dataBase.UpdateOneAsync(filter, update);
    }
}