using E_Commerce.Web.Extensions;
using Persistence.Configurations;
using ServiceImplementation.Configurations;
namespace E_Commerce.Web;

public class Program {
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Add services to the container. 
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructreServices(builder.Configuration);
        builder.Services.AddWebApplicationServices();                 
        #endregion
        var app = builder.Build();

        await app.SeedDataBasedAsync();
        // Configure the HTTP request pipeline.
        app.UseCustomeExceptionMiddleware();
        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApiMiddlewares();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
