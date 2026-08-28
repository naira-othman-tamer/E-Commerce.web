using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_Commerce.Web.Extensions;
public static class ServiceRegistration
{
    public static IServiceCollection AddWebApplicationServices(this IServiceCollection Services)
    {
        Services.AddControllers();
        Services.AddOpenApi();
        Services.AddEndpointsApiExplorer();
        Services.AddSwaggerGen();
        Services.AddHttpContextAccessor();
        Services.Configure<ApiBehaviorOptions>((options) =>
        {
            options.InvalidModelStateResponseFactory = ApiResponseFactory
                                                      .GenerateApiValidationErrorResponse;
        });
        return Services;
    }

    public static IServiceCollection AddJWTServices(this IServiceCollection Services, IConfiguration configuration)
    {
        Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = configuration["JWTOptions : Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["JWTOptions : Audience"],
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWTOptions : SecretKey"]))
            };
        });
        return Services;
    }
}
