using Domain.Contracts;
using E_Commerce.Web.CustomMiddlewares;
using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories;
using Scalar.AspNetCore;
using ServiceAbstraction;
using ServiceImplementation;
using ServiceImplementation.MappingProfiles;
using Shared.ErrorModels;
namespace E_Commerce.Web;

public class Program {
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IDataSeeding, DataSeeding>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IServiceManager, ServiceManager>();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDbContext<StoreDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
        });
        builder.Services.AddAutoMapper(
            cfg=> { },
            typeof(ProductProfile).Assembly);

        builder.Services.Configure<ApiBehaviorOptions>((options) =>
        {
            options.InvalidModelStateResponseFactory = ApiResponseFactory
                                                      .GenerateApiValidationErrorResponse;
        });
        #endregion

        var app = builder.Build();

        try
        {
            using var Scope = app.Services.CreateScope();
            var objectOdDataSeeding = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await objectOdDataSeeding.DataSeedAsync();
        }
        catch (Exception)
        {
            throw;
        }

        //app.Use(async (RequestContext, NextMiddleWare) =>
        //{
        //    Console.WriteLine("Request Under Processing");
        //    await NextMiddleWare.Invoke();
        //    Console.WriteLine("Waiting Response");
        //    Console.WriteLine(RequestContext.Response.Body.ToString());
        //});

        // Configure the HTTP request pipeline.
        app.UseMiddleware<CustomExceptionHandlerMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            //https://localhost:7069/scalar/v1
            app.MapScalarApiReference();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
