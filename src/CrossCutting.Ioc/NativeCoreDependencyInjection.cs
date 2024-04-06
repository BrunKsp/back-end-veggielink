using aplication.Services;
using data.domain.Context;
using infra.Interfaces;
using infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VeggieLink.CrossCutting.IoC;

public static class NativeCoreDependencyInjection
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddScoped<DbContext>();

        #region Repositorys
        services.AddScoped<IProductRepository, ProductRepository>();
        #endregion

        #region Services
        services.AddScoped<IProductService, ProductService>();
        #endregion

        services.AddScoped(x =>
      {
          var context = x.GetRequiredService<DbContext>();
          return context.ProductCollection;
      });
    }
}