
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Scalar.AspNetCore;

namespace E_Commerce.Web
{
    public class Program
    {
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

            builder.Services.AddDbContext<StoreDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
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

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                //https://localhost:7069/scalar/v1
                app.MapScalarApiReference();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
