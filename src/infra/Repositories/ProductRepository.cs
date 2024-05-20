using data.domain.Collections;
using data.domain.Context;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using VeggieLink.Data.Collections;
using VeggieLink.Infra.domain.Dtos;
using VeggieLink.Infra.Interfaces;

namespace VeggieLink.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    protected IMongoCollection<ProductCollection> _dataBase;
    protected IMongoCollection<CategoryCollection> _category;

    public ProductRepository(DbContext context, IMongoCollection<CategoryCollection> category)
    {
        _dataBase = context.ProductCollection;
        _category = category;
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
    public async Task<List<ProductWithCategory>> GetProductsWithCategoriesAsync()
    {
        var bsonProducts = await _dataBase.Aggregate()
            .Lookup<ProductCollection, CategoryCollection, ProductWithCategory>(
                _category,
                product => product.CategoryId,
                category => category.Id,
                product => product.CategoryDetails
            )
            .Unwind("CategoryDetails")
            .Project<BsonDocument>(
                Builders<BsonDocument>.Projection

                    .Include("Status")
                    .Include("Name")
                    .Include("Description")
                    .Include("Thumb")
                    .Include("PlantingDate")
                    .Include("HarvestDate")
                    .Include("CategoryId")
                    .Include("CategoryDetails.Name")

            )
            .ToListAsync();
        var productsWithCategories = bsonProducts.Select(bsonProduct =>
        {
            return BsonSerializer.Deserialize<ProductWithCategory>(bsonProduct);
        }).ToList();
        return productsWithCategories;
    }

}