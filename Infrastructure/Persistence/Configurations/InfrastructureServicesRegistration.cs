using Persistence.Identity;
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
        Services.AddScoped<IBasketRepository, BasketRepository>();
        Services.AddSingleton<IConnectionMultiplexer>((_) =>
        {
           return ConnectionMultiplexer.Connect(Configuration
                 .GetConnectionString("RedisConnectionString"));
        } );
        Services.AddDbContext<StoreIdentityDbContext>(opt =>
        {
            opt.UseSqlServer(Configuration.GetConnectionString("StoreIdentityConnection"));
        });
        Services.AddIdentityCore<ApplicationUser>(options =>
        {
           
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<StoreIdentityDbContext>();
        return Services;
    }
}
