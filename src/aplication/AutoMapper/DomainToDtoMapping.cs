using aplication.Dtos.Products;
using AutoMapper;
using data.domain.Collections;
using Microsoft.Extensions.Configuration;

namespace aplication.AutoMapper;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping(IConfiguration config)
    {
        CreateMap<ProductCollection, ListProductDto>();
    }
}