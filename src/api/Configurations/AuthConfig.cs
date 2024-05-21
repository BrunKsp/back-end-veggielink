using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace VeggieLink.Api.Configurations
{
    public static class AuthConfig
    {
        public static void AuthServiceConfig(this IServiceCollection services, IConfiguration config)
        {
            var jwtSettings = config["Jwt:Settings"];

            if (string.IsNullOrEmpty(jwtSettings))
            {
                throw new ArgumentNullException(nameof(jwtSettings), "Configuration value for 'Jwt:Settings' is missing.");
            }

            var key = Encoding.ASCII.GetBytes(jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false
                };
            });
        }

        public static void AuthAppConfig(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }

}