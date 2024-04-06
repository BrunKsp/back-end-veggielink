using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace aplication.AutoMapper;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping(IConfiguration config)
    {
    }
}