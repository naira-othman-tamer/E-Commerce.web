using E_Commerce.Web.Extensions.Helper;
namespace E_Commerce.Web.Extensions;

public static class OpenApiServiceExtensions
{
    public static IServiceCollection AddOpenApiWithJwtBearer(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
            options.AddDocumentTransformer<BearerSecuritySchemeTransformer>());

        return services;
    }
}
