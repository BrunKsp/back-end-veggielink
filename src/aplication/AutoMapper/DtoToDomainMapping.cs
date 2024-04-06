using aplication.Dtos.Products;
using AutoMapper;
using data.domain.Collections;

namespace aplication.AutoMapper;

public class DtoToDomainMapping : Profile
{
    public DtoToDomainMapping()
    {
        CreateMap<CreateProductDto, ProductCollection>();
    }
}