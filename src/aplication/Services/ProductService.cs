using aplication.Dtos.Products;
using aplication.Validators.ProductValidator;
using AutoMapper;
using data.domain.Collections;
using infra.Interfaces;

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
    public Task Create(CreateProductDto dto)
    {
        Validate(new CreateProductValidator(), dto);

        var product = _mapper.Map<ProductCollection>(dto);

        return _repository.Create(product);
    }
}