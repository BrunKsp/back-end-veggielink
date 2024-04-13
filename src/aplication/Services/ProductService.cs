using aplication.Dtos.Products;
using aplication.Exceptions;
using AutoMapper;
using data.domain.Collections;
using VeggieLink.Aplication.Dtos.Products;
using VeggieLink.Aplication.Validators.ProductValidator;
using VeggieLink.Infra.Interfaces;

namespace aplication.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task Create(CreateProductDto dto)
    {
        Validate(new CreateProductValidator(), dto);

        var product = _mapper.Map<ProductCollection>(dto);

        await _repository.Create(product);
    }
    public async Task<List<ListProductDto>> GetAllProducts()
    {
        var product = await _repository.GetAllProducts();

        return _mapper.Map<List<ListProductDto>>(product);
    }
    public async Task<ListProductDto> GetProduct(string id)
    {
        var product = await _repository.GetProduct(id) ?? throw CustomException.EntityNotFound(new { error = "Produto não encontrado" });

        return _mapper.Map<ListProductDto>(product);
    }
    public async Task ChangeProduct(ChangeProductDto dto, string id)
    {
        Validate(new ChangeProductValidator(), dto);
        var product = await _repository.GetProduct(id) ?? throw CustomException.EntityNotFound(new { error = "Produto não encontrado" });

        var newproduct = new ProductCollection
        {
            Name = dto.Name,
            Description = dto.Description,
            PlantingDate = dto.PlantingDate,
            HarverstDate = dto.HarverstDate,
            Status = dto.Status
        };
        await _repository.UpdateProduct(newproduct, id);
    }
}