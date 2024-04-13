using aplication.Services;
using data.domain.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeggieLink.Aplication.Interfaces;
using VeggieLink.Aplication.Services;
using VeggieLink.Infra.Interfaces;
using VeggieLink.Infra.Repositories;

namespace VeggieLink.CrossCutting.IoC;

public static class NativeCoreDependencyInjection
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddScoped<DbContext>();

        #region Repositorys
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        #endregion

        #region Services
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        #endregion

        services.AddScoped(x =>
      {
          var context = x.GetRequiredService<DbContext>();
          return context.ProductCollection;
      });
    }
}