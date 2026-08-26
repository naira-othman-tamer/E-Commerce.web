using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;
namespace Persistence.Configurations;
public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructreServices(this IServiceCollection Services,
                                                               IConfiguration Configuration)
    {
        Services.AddDbContext<StoreDbContext>(opt =>
        {
            opt.UseSqlServer(Configuration.GetConnectionString("cs"));
        });
        Services.AddScoped<IDataSeeding, DataSeeding>();
        Services.AddScoped<IUnitOfWork, UnitOfWork>();
        return Services;
    }
}
