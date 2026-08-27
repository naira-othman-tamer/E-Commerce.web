using Domain.Contracts;
using Scalar.AspNetCore;
using E_Commerce.Web.CustomMiddlewares;
namespace E_Commerce.Web.Extensions;
public static class WebApplicationRegistration
{
    public static async Task<WebApplication> SeedDataBasedAsync (this WebApplication app)
    {
        using var Scope = app.Services.CreateScope();
        var DataSeedingObject = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
        await DataSeedingObject.DataSeedAsync();
        await DataSeedingObject.IdentityDataSeedAsync();
        return app;
    }

    public static IApplicationBuilder UseCustomeExceptionMiddleware (this IApplicationBuilder app)
    {
        //app.Use(async (RequestContext, NextMiddleWare) =>
        //{
        //    Console.WriteLine("Request Under Processing");
        //    await NextMiddleWare.Invoke();
        //    Console.WriteLine("Waiting Response");
        //    Console.WriteLine(RequestContext.Response.Body.ToString());
        //});
        app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        return app;
    }

    public static WebApplication UseOpenApiMiddlewares(this WebApplication app)
    {
        app.MapOpenApi();
        //https://localhost:7069/scalar/v1
        app.MapScalarApiReference();
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}
