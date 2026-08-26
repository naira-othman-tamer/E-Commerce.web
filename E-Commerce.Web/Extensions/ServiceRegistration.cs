using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;

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
}
